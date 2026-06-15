namespace Escape_Room_2.ServerER
{
    /// <summary>
    /// משמשת לשמירת נתוני השחקן לצורך התחברות או הרשמה למערכת. 
    /// מרכזת את כל המידע הנדרש לזיהוי המשתמש 
    /// לביצוע בקשות לשרת של התחברות או הרשמה 
    /// </summary>
    public class PlayerInfo
    {
        public string Username { get; set; } //שם המשתמש של השחקן
        public string Email { get; set; } //כתובת דוא"ל עבור הרשמה
        public string HashedPassword { get; set; } // סיסמה מוצפנת בצד הלקוח לפני השליחה לשרת

        public string RequestType { get; set; } // סוג הבקשה ("SIGNUP" או "LOGIN" הרשמה או התחברות ) 

        /// <summary>
        /// יוצרת אובייקט חדש מסוג PlayerInfo
        /// ומאתחלת את כל תכונות המחלקה לפי הנתונים שהתקבלו
        /// לצורך שימוש במערכת וניהול תהליך ההתחברות או ההרשמה
        /// <summary>
        public PlayerInfo(string username, string email, string hashedPassword, string requestType)
        {
            Username = username;
            Email = email;
            HashedPassword = hashedPassword;
            RequestType = requestType;
        }
    }
}
