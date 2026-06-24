using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Escape_Room_2.GameHelpers
{
    /// <summary>
    /// המחלקה אחראית על ניהול התקשורת בין הלקוח לשרת במהלך המשחק.
    /// המחלקה שומרת על חיבור TCP פעיל
    /// מאפשרת שליחת הודעות לשרת ומאזינה להודעות המתקבלות ממנו בזמן אמת.
    /// </summary>
    public class GameConnection
    {
        //אובייקט החיבור המשמש לחיבור בין הלקוח לשרת
        public TcpClient Client { get; private set; }

        //משמש לשליחת הודעות מהלקוח לשרת
        public StreamWriter Writer { get; private set; }

        //שם המשתמש של השחקן המחובר למערכת
        public string Username { get; private set; }

        //אירוע המופעל בכל פעם שמתקבלת הודעה חדשה מהשרת
        public event Action<string> MessageReceived;

        //משמש לקריאת הודעות המתקבלות מהשרת
        private StreamReader Reader;

        //אירוע המופעל ברגע שהשרת מתנתק
        public event Action ServerDisconnected;

        //השחקן ניתק את החיבור במכוון
        private bool intentionallyClosed = false;

        /// <summary>
        /// יוצרת אובייקט חדש מסוג GameConnection
        /// שומרת את נתוני החיבור ומפעילה את פעולת ההאזנה להודעות מהשרת
        /// </summary>
        public GameConnection(TcpClient client, StreamReader reader, StreamWriter writer, string username)
        {
            Client = client;
            Reader = reader;
            Writer = writer;
            Username = username;
            _ = ListenLoop();
        }

        /// <summary>
        /// מאזינה באופן רציף להודעות המגיעות מהשרת
        /// כל פעם שמתקבלת הודעה חדשה, 
        /// מפעילה את האירוע MessageReceived 
        /// לצורך טיפול בהודעה
        /// הפעולה מסתיימת כאשר החיבור לשרת נסגר
        /// </summary>
        private async Task ListenLoop()
        {
            try
            {
                while (true)
                {
                    string message = await Reader.ReadLineAsync();
                    if (message == null) break;
                    MessageReceived?.Invoke(message);
                }
            }
            catch (Exception)
            {
                // שגיאת חיבור
            }
            finally
            {
                if (!intentionallyClosed)
                    ServerDisconnected?.Invoke();
            }
        }

        /// <summary>
        /// מקבלת מחרוזת הודעה שיש לשלוח לשרת
        /// שולחת הודעה לשרת דרך החיבור הפעיל
        /// לא מחזירה ערך
        /// </summary>
        public void Send(string message)
        {
            try
            {
                Writer.WriteLine(message);
            }
            catch (Exception)
            {
                // השרת התנתק אין אפשרות לשלוח את ההודעה
            }
        }


        /// <summary>
        /// משמשת לסגירת החיבור בין הלקוח לשרת במכוון
        /// לא מחזירה ערך
        /// </summary>
        public void Close()
        {
            intentionallyClosed = true;
            try { Client.Close(); }
            catch { }
        }

    }
}