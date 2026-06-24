using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Escape_Room_2.GameHelpers;


namespace Escape_Room_2.ServerER
{
    /// <summary>
    /// מחלקה זו אחראית על ניהול התקשורת בין השרת לבין שחקן בודד
    /// היא מטפלת בתהליך ההתחברות, קבלת הודעות מהלקוח
    /// שליחת תגובות מתאימות וביצוע פעולות שונות במהלך המשחק
    /// </summary>
    public class PlayerHandler
    {
        #region Properties
        private TcpClient client; 
        private Server server;
        #endregion

        #region Methods
        /// <summary>
        /// מקבלת אובייקט TcpClient המייצג את השחקן המחובר
        /// ואובייקט Server המייצג את השרת.
        /// יוצרת אובייקט חדש מסוג PlayerHandler ושומרת את נתוני החיבור לצורך 
        /// ניהול התקשורת עם השחקן
        /// </summary>
        public PlayerHandler(TcpClient client, Server server) { 
            this.client = client; 
            this.server = server;   
        }

        /// <summary>
        /// – מטפלת בכל תהליך התקשורת מול השחקן
        /// הפעולה מקבלת את נתוני ההתחברות או ההרשמה, בודקת אותם מול השרת ושולחת תשובה ללקוח
        /// לאחר התחברות מוצלחת היא מאזינה להודעות 
        /// המתקבלות מהשחקן ומטפלת בהן בהתאם לסוג ההודעה
        /// </summary>
        public async Task HandlePlayer()
        {
            string Username = null;
            try
            {
                NetworkStream networkStream = client.GetStream();



                StreamReader reader = new StreamReader(networkStream);
                StreamWriter writer = new StreamWriter(networkStream)
                {
                    AutoFlush = true
                }; 
                string json = await reader.ReadLineAsync();
                if (json == null)
                {
                    client.Close();
                    return;
                }

                PlayerInfo info = JsonSerializer.Deserialize<PlayerInfo>(json);
                if (server.IsGameRunning())
                {
                    await writer.WriteLineAsync("GAME IN PROGRESS");
                    client.Close();
                    return;
                }
                Username = info.Username; 
                System.Diagnostics.Debug.WriteLine($"Incoming request from: {info.Username}");

                
                string result;

                if (info.RequestType == GameProtocol.Signup)
                {
                    result = server.Signup(info);
                }
                else if (info.RequestType == GameProtocol.Login)
                {
                    result = server.Login(info);
                }
                else
                {
                    result = "UNKNOWN";
                }


                
                await writer.WriteLineAsync(result);

                
                if (result != "OK")
                {
                    server.Log($"{info.Username} failed to connect ({result}).");
                    client.Close();
                    return;
                }

                
                server.Log($"{info.Username} connected successfully.");
                ActivePlayer connectedClient = new ActivePlayer(info.Username, writer);
                server.AddClient(connectedClient);

                
                while (client.Connected)
                {
                    string message = await reader.ReadLineAsync();

                    // NULL
                    if (message == null)
                    {
                        server.Log($"{info.Username} disconnected.");
                        server.RemovePlayer(info.Username);
                        break;
                    }

                    // CHAT
                    if (message.StartsWith(GameProtocol.ChatMsg))
                    {
                        string content = message.Substring(GameProtocol.ChatMsg.Length);
                        int idx = content.IndexOf(':');

                        string username = content.Substring(0, idx);
                        string chatMessage = content.Substring(idx + 1);
                        server.Log($"{username}: {chatMessage}");
                        server.BroadcastChat(username, chatMessage);
                    }

                    // ANSWER
                    else if (message.StartsWith(GameProtocol.Answer))
                    {
                        string content = message.Substring(GameProtocol.Answer.Length);
                        int idx = content.IndexOf(':');

                        string username = content.Substring(0, idx);
                        string answer = content.Substring(idx + 1);
                        server.Log($"{username} submitted answer: {answer}");
                        server.HandleAnswer(username, answer);
                    }

                    // READY
                    else if (message == GameProtocol.Ready)
                    {
                        server.Log($"{info.Username} is ready.");
                        server.PlayerReady();
                    }

                    // REVEAL
                    else if (message == GameProtocol.Reveal)
                    {
                        server.Log($"{info.Username} revealed the answer.");
                        server.RevealAnswer();
                    }
                    //REQUESTCOUNT
                    else if (message == GameProtocol.RequestCount)
                    {
                        Task.Delay(1000);
                        server.BroadcastPlayerCount();
                    }
                    // UNKNOWN
                    else
                    {
                        server.Log($"Unknown message received from {info.Username}: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                server.Log(ex.Message);
            }
            finally
            {
                if (Username != null)
                {
                    server.RemovePlayer(Username);
                }

                client.Close();
            }
        }
    }


    #endregion
}

