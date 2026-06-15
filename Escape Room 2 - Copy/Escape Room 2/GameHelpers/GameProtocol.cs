namespace Escape_Room_2.GameHelpers
{
    /// <summary>
    ///מכיל את כל קבועי הפקודות וההודעות של
    ///פרוטוקול התקשורת המשמשים לתקשורת בין הלקוחות לשרת
    ///אם מופיע : סימן שיש נתונים שבאים אחרי התחילית
    ///אם זו מילה בודדה אז זו הודעת פקודה או אות
    /// </summary>


    public static class GameProtocol
    {
        /// <summary>
        /// הודעות מהשרת ללקוח
        /// </summary>
        public const string Chat = "CHAT:"; //הודעת צ'אט 
        public const string Puzzle = "PUZZLE:"; //חידה חדשה
        public const string Hint = "HINT:"; //הצגת רמז
        public const string Next = "NEXT"; //מעבר לחידה הבאה
        public const string ShowReveal = "SHOWREVEAL"; //פקודה להציג את כפתור Reveal
        public const string HideReveal = "HIDEREVEAL"; //פקודה להציג את כפתור
        public const string GameOver = "GAMEOVER"; //סיום המשחק
        public const string Start = "START"; //תחילת תהליך ההכנה למשחק
        public const string StartGame = "STARTGAME"; //תחילת המשחק עצמו
        public const string Players = "PLAYERS:"; //מכילה מידע על השחקנים המחוברים
        public const string PlayerDisconnected = "PLAYERDISCONNECTED:"; //ניתוק שחקן

        /// <summary>
        /// הודעות מהלקוח לשרת
        /// </summary>
        public const string Login = "LOGIN"; //בקשת התחברות של משתמש למערכת
        public const string Signup = "SIGNUP"; //בקשת הרשמה של משתמש חדש
        public const string ChatMsg = "CHATMSG:"; //הודעת צ'אט הנשלחת מהלקוח לשרת
        public const string Answer = "ANSWER:"; //תשובה שנשלחת על ידי שחקן
        public const string Ready = "READY"; //הודעה שהשחקן מוכן להתחיל את המשחק
        public const string Reveal = "REVEAL"; //בקשה לחשיפת התשובה
    }
}
