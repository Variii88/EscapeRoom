using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace Escape_Room_2.ServerER
{
    /// <summary>
    ///מחלקה זו אחראית על ניהול חשבונות המשתמשים במערכת
    ///היא מטפלת בתהליכי הרשמה, התחברות ואבטחת סיסמאות
    ///המחלקה מתקשרת עם מסד הנתונים לצורך שמירה ובדיקת פרטי המשתמשים
    /// </summary>
    public class AccountManager
    {
        // מחרוזת חיבור למסד הנתונים
        private readonly string connectionString;

        // קבוע סודי מצורף לסיסמה לצורך אבטחה נוספת
        private const string Pepper = "EscapeRoom_SecretPepper_2026";

        /// <summary>
        ///מקבלת מחרוזת חיבור למסד הנתונים ושומרת אותה לצורך
        ///עבודה מול מסד הנתונים, ביצירת אובייקט חדש מסוג AccountManager 
        /// </summary>

        // ניסיונות כושלים עבור משתמש
        private Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
        // המשתמש הושבת
        private Dictionary<string, DateTime> blockedUntil = new Dictionary<string, DateTime>();
        public AccountManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        ///יוצרת ומחזירה ערך Salt 
        ///אקראי מסוג מחרוזת שמתווסף לסיסמת המשתמש
        ///כחלק מתהליך הצפנתה ולצורך אבטחה מוגברת
        /// </summary>
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(saltBytes);
            return BitConverter.ToString(saltBytes).Replace("-", "");
        }

        /// <summary>
        ///מקבלת סיסמה מוצפנת שהתקבלה מהלקוח וערך Salt
        ///מחברת את הסיסמה ה Salt וה Pepper
        //מבצעת עליהם פעולת Hash באמצעות SHA256
        ///ומחזירה את הערך המוצפן הסופי
        /// </summary>
        private string HashPassword(string clientHash, string salt)
        {
            string combined = clientHash + salt + Pepper;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        ///הפעולה מבצעת הרשמה של משתמש למערכת
        ///מקבלת אובייקט מסוג PlayerInfo המכיל את פרטי המשתמש לצורך הרשמה
        ///בודקת האם שם המשתמש כבר קיים במסד הנתונים
        ///אם המשתמש קיים מוחזר "EXISTS"
        ///אם המשתמש אינו קיים הפעולה יוצרת Salt חדש
        ///מצפינה את הסיסמה באמצעות HashPassword
        ///שומרת את המשתמש במסד הנתונים ומחזירה "OK"
        /// </summary>
        public string Signup(PlayerInfo info)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                //האם המשתמש כבר קיים
                string checkQuery = "SELECT COUNT(*) FROM EscapeRoomUsers WHERE username = @u";
                using (SQLiteCommand cmd = new SQLiteCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@u", info.Username);
                    if ((long)cmd.ExecuteScalar() > 0)
                        return "EXISTS";
                }

                string salt = GenerateSalt();
                string finalHash = HashPassword(info.HashedPassword, salt);

                //הכנסת משתמש חדש לטבלה
                string insertQuery = "INSERT INTO EscapeRoomUsers (username, email, hashedPassword, salt) VALUES (@u, @e, @p, @s)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@u", info.Username);
                    cmd.Parameters.AddWithValue("@e", info.Email);
                    cmd.Parameters.AddWithValue("@p", finalHash);
                    cmd.Parameters.AddWithValue("@s", salt);
                    cmd.ExecuteNonQuery();
                    return "OK";
                }
            }
        }

        /// <summary>
        ///הפעולה מבצעת התחברות של משתמש למערכת
        ///מקבלת אובייקט מסוג PlayerInfo המכיל את פרטי המשתמש לצורך התחברות
        ///בודקת אם שם המשתמש קיים, מבצעת הצפנה מחדש של הסיסמה שהתקבלה
        ///ומשווה אותה לסיסמה השמורה בטבלה
        ///אם שם המשתמש לא קיים או הסיסמה שגויה מוחזר "WRONG"
        ///אם הנתונים תקינים מוחזר "OK"
        /// </summary>
        public string Login(PlayerInfo info)
        {

            if (blockedUntil.ContainsKey(info.Username))
            {
                if (DateTime.Now < blockedUntil[info.Username])
                {
                    TimeSpan remaining = blockedUntil[info.Username] - DateTime.Now;
                    return $"BLOCKED:{(int)remaining.TotalSeconds}";
                }
                else
                {
                    blockedUntil.Remove(info.Username);
                    failedAttempts.Remove(info.Username);
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT hashedPassword, salt FROM EscapeRoomUsers WHERE username = @u";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", info.Username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return "WRONG";

                        string storedHash = reader["hashedPassword"].ToString();
                        string salt = reader["salt"].ToString();

                        string finalHash = HashPassword(info.HashedPassword, salt);
                        if (finalHash == storedHash)
                        {
                            failedAttempts.Remove(info.Username);
                            return "OK";
                        }
                        else
                        {
                            if (!failedAttempts.ContainsKey(info.Username))
                                failedAttempts[info.Username] = 0;
                            failedAttempts[info.Username]++;

                            if (failedAttempts[info.Username] >= 5)
                            {
                                blockedUntil[info.Username] = DateTime.Now.AddMinutes(2);
                                return "BLOCKED:120";
                            }

                            return "WRONG";
                        }
                    }
                }
            }
        }
    }
}
