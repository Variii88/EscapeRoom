using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Escape_Room_2.ServerER;

namespace Escape_Room_2.GameHelpers
{
    /// <summary>
    ///מחלקה סטטית המכילה פעולות עזר הקשורות לשחקן
    ///המחלקה אחראית על הצפנת סיסמאות בצד הלקוח 
    ///ועל יצירת חיבור לשרת לצורך התחברות או הרשמה למערכת
    /// </summary>
    static class PlayerHelper
    {
        #region Methods

        /// <summary>
        ///מקבלת מחרוזת סיסמה שהוזנה על ידי המשתמש
        ///מבצעת הצפנה של הסיסמה באמצעות אלגוריתם SHA256
        /// ומחזירה את הערך המוצפן כמחרוזת
        /// </summary>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        /// <summary>
        ///מקבלת אובייקט מסוג PlayerInfo 
        ///המכיל את פרטי המשתמש,
        /// מחרוזת של כתובת ה IP של השרת
        ///ומשתנה מסוג string לקבלת תשובת השרת.
        /// יוצרת חיבור לשרת באמצעות TCP
        /// שולחת את נתוני המשתמש בפורמט JSON
        //אם התקבלה תשובת OK מהשרת וההתחברות או ההרשמה הצליחו, 
        ///הפעולה מחזירה אובייקט מסוג GameConnection
        ///המאפשר המשך תקשורת עם השרת במהלך המשחק
        ///אם הפעולה נכשלה, החיבור נסגר ומוחזר הערך null.
        /// </summary>
        public static GameConnection ConnectToServer(PlayerInfo playerInfo, string serverIP, out string response)
        {
            string json = JsonSerializer.Serialize(playerInfo);
            TcpClient client = new TcpClient();
            client.Connect(serverIP, Server.Port);
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream);
            writer.WriteLine(json);
            response = reader.ReadLine();

            if (response == "OK")
                return new GameConnection(client, reader, writer, playerInfo.Username);

            client.Close();
            return null;
        }
        #endregion
    }
}
