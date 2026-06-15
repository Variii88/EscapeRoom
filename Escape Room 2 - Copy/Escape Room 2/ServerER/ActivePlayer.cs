using System.IO;

namespace Escape_Room_2.ServerER
{
    /// <summary>
    ///מחלקה זו מייצגת שחקן המחובר כעת לשרת
    ///המחלקה שומרת את המידע הדרוש לניהול השחקן במהלך המשחק,
    ///כגון שם המשתמש שלו, אמצעי התקשורת מולו ומצבו הנוכחי.
    /// </summary>
    public class ActivePlayer
    {
        public string Username { get; set; } 
        public StreamWriter Writer { get; set; }
        public string Status { get; set; } //סטטוס השחקן, האם מחכה בחדר ההמתנה או משחק "waiting" או "playing"

        /// <summary>
        ///יוצרת אובייקט חדש מסוג ActivePlayer
        ///שומרת את פרטי השחקן ומגדירה את מצבו ההתחלתי כ "waiting"
        /// </summary>
        public ActivePlayer(string username, StreamWriter writer)
        {
            Username = username;
            Writer = writer;
            Status = "waiting";
        }
    }
}
