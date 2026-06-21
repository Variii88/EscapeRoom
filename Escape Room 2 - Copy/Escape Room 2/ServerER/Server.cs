using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escape_Room_2.Game;
using Escape_Room_2.GameHelpers;

namespace Escape_Room_2.ServerER
{
    /// <summary>
    /// מחלקה זו היא המחלקה המרכזית של השרת
    /// היא אחראית על ניהול החיבורים של השחקנים,
    /// ניהול המשחק, שליחת הודעות בין הלקוחות, טיפול בהרשמה והתחברות,
    /// ובקרה על התקדמות המשחק מתחילתו ועד סופו
    /// </summary>
    public class Server
    {
        #region DATA & FIELDS

        // Database מסד הנתונים וטבלה
        const string dbFileName = "database.db"; //שם קובץ מסד הנתונים של המערכת 
        static string ConnectionString =>
            $"Data Source={Path.Combine(Application.StartupPath, dbFileName)};Version=3;";
        private string connectionString; // מחרוזת החיבור למסד הנתונים

        // רשת
        public const int Port = 6000; // מספר הפורט שעליו השרת מאזין לחיבורים חדשים
        private TcpListener conListener = null; //אחראי על קבלת חיבורים חדשים מהלקוחות  
        private CancellationTokenSource cnclKey = null; // מאפשר לעצור את פעולת ההאזנה של השרת במקרה הצורך
        private UDPBroadcaster udpBroadcaster; // אחראי על שידור כתובת השרת ברשת המקומית


        // שחקנים מחוברים
        private List<ActivePlayer> connectedPlayers = new List<ActivePlayer>(); // רשימה המכילה את כל השחקנים המחוברים כעת לשרת
        private readonly object lockObject = new object(); // משמש לסנכרון פעולות בין מספר תהליכונים ומונע גישה בו זמנית לנתונים משותפים
        private int readyCount = 0; //מספר השחקנים שסימנו שהם מוכנים להתחיל את המשחק


        // לוגיקת משחק
        private PuzzleManager puzzleManager = new PuzzleManager();
        private int correctAnswersCount = 0;
        private HashSet<string> correctPlayers = new HashSet<string>();
        private enum GameState { Waiting, Playing } 
        private GameState gameState = GameState.Waiting;

        // ניהול משתמשים
        private AccountManager accountManager;

        //שרת
        private ServerUI serverUI;
        #endregion


        #region STARTUP & SERVER LOOP

        /// <summary>
        /// מקבלת אובייקט מסוג ServerUI.
        /// יוצרת אובייקט Server חדש, מאתחלת את רכיבי המערכת ומפעילה את השרת.
        /// </summary>
        public Server(ServerUI serverUI)
        {
            this.serverUI = serverUI;
            this.connectionString = ConnectionString;
            accountManager = new AccountManager(connectionString);
            Task.Run(() => ActivateServer());
        }

        /// <summary>
        /// יוצרת את מסד הנתונים ואת טבלת המשתמשים אם לא קיימים
        /// </summary>
        private void SetupDatabase()
        {
            EscapeRoomDatabase.InitDB(ConnectionString, dbFileName);
        }

        /// <summary>
        /// מנקה את טבלת הנתונים
        /// </summary>
        public void ClearDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM EscapeRoomUsers", conn))
                    cmd.ExecuteNonQuery();
            }
            Log("Database cleared successfully.");
        }

        /// <summary>
        /// פותחת את השרת להאזנה לחיבורים חדשים באמצעות TCP
        /// </summary>
        private void OpenConnection()
        {
            conListener = new TcpListener(IPAddress.Any, Port);
            conListener.Start();
            cnclKey = new CancellationTokenSource();
        }

        /// <summary>
        /// מאזינה לחיבורים חדשים ומייצרת אובייקט PlayerHandler עבור כל שחקן שמתחבר לשרת.
        /// </summary>
        private async Task AcceptingPlayersLoop(TcpListener conListener, CancellationTokenSource cnclKey)
        {
            int clientNumber = 0;
            while (!cnclKey.Token.IsCancellationRequested)
            {
                TcpClient client = await conListener.AcceptTcpClientAsync();
                serverUI.Log($"Client {++clientNumber} connected.");
                PlayerHandler playerhandler = new PlayerHandler(client, this);
                Task.Run(() => playerhandler.HandlePlayer());
                await Task.Delay(500);
            }
        }

        /// <summary>
        /// מפעילה את השרת, יוצרת את מסד הנתונים, מפעילה את שליחת הודעת השרת ברשת ומתחילה לקבל שחקנים חדשים
        /// </summary>
        public void ActivateServer()
        {
            SetupDatabase();
            OpenConnection();
            udpBroadcaster = new UDPBroadcaster();
            udpBroadcaster.StartBroadcasting();
            _ = AcceptingPlayersLoop(conListener, cnclKey);
        }
        #endregion


        #region הרשמה או התחברות

        /// <summary>
        /// מקבלת אובייקט מסוג PlayerInfo המכיל את פרטי המשתמש
        /// מבצעת הרשמה של משתמש חדש ומחזירה את תוצאת הפעולה
        /// </summary>
        public string Signup(PlayerInfo info) => accountManager.Signup(info);

        /// <summary>
        /// מקבלת אובייקט מסוג PlayerInfo המכיל את פרטי המשתמש
        /// בודקת את נתוני המשתמש ומחזירה את תוצאת ההתחברות
        /// </summary>
        public string Login(PlayerInfo info) => accountManager.Login(info);

        #endregion


        #region ניהול לקוחות

        /// <summary>
        /// מקבלת אובייקט מסוג ActivePlayer.
        /// מוסיפה שחקן חדש לרשימת השחקנים המחוברים ומעדכנת את כלל הלקוחות במספר השחקנים.
        /// </summary>
        public void AddClient(ActivePlayer client)
        {
            lock (lockObject)
            {
                connectedPlayers.Add(client);
            }
            Task.Delay(500).ContinueWith(_ => BroadcastPlayerCount());
        }

        /// <summary>
        /// שולחת לכל השחקנים את מספר השחקנים המחוברים
        /// כאשר שלושה שחקנים מחוברים נשלחת הודעת START
        /// </summary>
        public void BroadcastPlayerCount()
        {
            lock (lockObject)
            {
                Log($"Broadcasting player count: {connectedPlayers.Count}/3");
                string message = $"{GameProtocol.Players}{connectedPlayers.Count}/3 Players joined";
                foreach (ActivePlayer client in connectedPlayers)
                    client.Writer.WriteLine(message);

                if (connectedPlayers.Count == 3)
                {
                    Task.Delay(1000).ContinueWith(_ =>
                    {
                        lock (lockObject)
                        {
                            foreach (ActivePlayer client in connectedPlayers)
                                client.Writer.WriteLine(GameProtocol.Start);
                        }
                    });
                }
            }
        }

        /// <summary>
        /// מקבלת את שם המשתמש של השחקן שהתנתק
        /// מסירה את השחקן מרשימת השחקנים המחוברים ומעדכנת את שאר השחקנים
        /// </summary>
        public void RemovePlayer(string username)
        {
            lock (lockObject)
            {
                connectedPlayers.RemoveAll(p => p.Username == username);
            }
            if (gameState == GameState.Waiting)
            {
               BroadcastToAll($"{GameProtocol.PlayerDisconnected}{username}");
               Log($"{username} removed from connected players.");
                Task.Delay(1000).ContinueWith(_ => BroadcastPlayerCount());
            }
             else
             {
                Log($"{username} removed from connected players.");
                BroadcastToAll($"{GameProtocol.PlayerDisconnected}{username}");
                ResetGame();
            }
        }

        /// <summary>
        /// מקבלת הודעה מסוג string
        /// ומציגה את ההודעה בחלון השרת
        /// </summary>
        public void Log(string message)
        {
            serverUI?.Log(message);
        }

        /// <summary>
        /// סוגרת את כל החיבורים הפעילים של השחקנים ומנקה את רשימת השחקנים
        /// </summary>
        public void CloseAllConnections()
        {
            lock (lockObject)
            {
                foreach (ActivePlayer player in connectedPlayers)
                {
                    try { player.Writer.Close(); }
                    catch { }
                }
                connectedPlayers.Clear();
            }
        }
        #endregion


        #region MESSAGING & BROADCAST

        /// <summary>
        /// מקבלת שם משתמש והודעת צ'אט
        /// שולחת את הודעת הצ'אט לכל השחקנים המחוברים
        /// </summary>
        public void BroadcastChat(string username, string message)
        {
            lock (lockObject)
            {
                string fullMessage = $"{GameProtocol.Chat}{username}: {message}";
                foreach (ActivePlayer client in connectedPlayers)
                    client.Writer.WriteLine(fullMessage);
            }
        }

        /// <summary>
        /// מקבלת הודעה מסוג string
        /// שולחת את ההודעה לכל השחקנים המחוברים
        /// </summary>
        public void BroadcastToAll(string message)
        {
            lock (lockObject)
            {
                foreach (ActivePlayer client in connectedPlayers)
                    client.Writer.WriteLine(message);
            }
        }

        /// <summary>
        /// עוצרת את שידור הודעת ה UDP של השרת ברשת המקומית
        /// </summary>
        public void StopUDPBroadcasting()
        {
            udpBroadcaster?.StopBroadcasting();
        }
        #endregion


        #region GAME LOGIC

        /// <summary>
        /// מקבלת את שם המשתמש ואת התשובה שהוזנה
        /// בודקת את התשובה, מעדכנת את מצב המשחק, מפעילה רמזים או
        /// Reveal במידת הצורך
        /// ומעבירה את המשחק לחידה הבאה כאשר כל השחקנים ענו נכון
        /// </summary>
        public void HandleAnswer(string username, string answer)
        {
            if (correctPlayers.Contains(username))
                return;
            lock (lockObject)
            {
                bool correct = puzzleManager.CheckAnswer(answer);

                if (correct)
                {
                    correctPlayers.Add(username);
                    correctAnswersCount++;
                    BroadcastChat("Server", $"{username} answered correctly! ({correctAnswersCount}/3)");

                    if (correctAnswersCount == 3)
                    {
                        correctAnswersCount = 0;
                        correctPlayers.Clear();
                        bool hasNext = puzzleManager.MoveNext();
                        if (hasNext)
                        {
                            BroadcastToAll(GameProtocol.Next);
                            Task.Delay(500).ContinueWith(_ => SendPuzzle());
                        }
                        else
                        {
                            BroadcastToAll(GameProtocol.GameOver);
                            Task.Delay(2000).ContinueWith(_ => ResetGame());
                        }
                    }
                }
                else
                {
                    BroadcastChat("Server", $"Wrong answer! ({puzzleManager.WrongAnswers} wrong answers)");

                    if (puzzleManager.ShouldShowHint())
                    {
                        BroadcastChat("Hint", puzzleManager.GetCurrentPuzzle().HintText);
                        BroadcastToAll($"{GameProtocol.Hint}{puzzleManager.GetCurrentPuzzle().HintImage}");
                    }

                    if (puzzleManager.ShouldShowReveal())
                        BroadcastToAll(GameProtocol.ShowReveal);
                }
            }
        }


        /// <summary>
        /// בונה את פרטי החידה הנוכחית ושולחת אותם לכל השחקנים
        /// </summary>
        public void SendPuzzle()
        {
            Puzzle puzzle = puzzleManager.GetCurrentPuzzle();
            string message = $"{GameProtocol.Puzzle}{puzzle.Type}|{puzzle.Question}|{puzzle.QuestionLocation}|{string.Join(",", puzzle.Images)}";

            if (puzzle.Choices != null)
                message += $"|CHOICES:{string.Join(",", puzzle.Choices)}";

            BroadcastToAll(message);
        }

        /// <summary>
        /// מעדכנת ששחקן מוכן למשחק
        /// כאשר שלושת השחקנים מוכנים המשחק מתחיל
        /// </summary>
        public void PlayerReady()
        {
            lock (lockObject)
            {
                readyCount++;
                if (readyCount == 3)
                {
                    readyCount = 0;
                    gameState = GameState.Playing;
                    BroadcastToAll(GameProtocol.StartGame);
                    Task.Delay(500).ContinueWith(_ => SendPuzzle());
                }
            }
        }

        /// <summary>
        /// חושפת את התשובה לחידה הנוכחית לכל השחקנים
        ///ומעדכנת את מספר פעמי השימוש ב Reveal 
        /// </summary>
        public void RevealAnswer()
        {
            lock (lockObject)
            {
                string answer = puzzleManager.GetCurrentPuzzle().Answer;
                BroadcastChat("Server", $"The answer is: {answer}");
                BroadcastToAll(GameProtocol.HideReveal);
                puzzleManager.UseReveal();
            }
        }

        /// <summary>
        /// מאפסת את כל נתוני המשחק ומכינה את השרת למשחק חדש
        /// </summary>
        public void ResetGame()
        {
            Log("ENTERED RESET GAME");
            BroadcastToAll(GameProtocol.GameOver);
            System.Threading.Thread.Sleep(500);
            lock (lockObject)
            {
                gameState = GameState.Waiting;
                connectedPlayers.Clear();
                readyCount = 0;
                correctAnswersCount = 0;
                correctPlayers.Clear();
                puzzleManager = new PuzzleManager();
            }

            Log("Game reset. Ready for new players.");
        }
        #endregion
    }
}

