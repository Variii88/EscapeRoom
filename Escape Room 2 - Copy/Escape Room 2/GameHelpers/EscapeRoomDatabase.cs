using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Escape_Room_2.GameHelpers
{
    /// <summary>
    /// מחלקת עזר המטפלת בהגדרה הראשונית של מסד הנתונים
    /// Database SQLite של המשחק.
    /// אחראית על יצירת מסד הנתונים ואתחולו בעת הפעלת המערכת.
    /// </summary>
    static class EscapeRoomDatabase
    {
        #region Methods

        /// <summary>
        /// מקבלת מחרוזת חיבור למסד הנתונים ואת שם קובץ מסד הנתונים
        /// יוצרת את קובץ טבלת מסד הנתונים ואת טבלת המשתמשים אם הם אינם קיימים.
        /// מסדרת שהטבלה מכילה את העמודות:
        /// שם משתמש
        /// כתובת אימייל
        ///Hash סיסמה מוצפנת בפונקציית 
        ///Salt ועמודת
        /// לא מחזירה ערך.
        /// </summary>
        public static void InitDB(string connectionString, string dbFileName)
        {
            string databasePath = Path.Combine(Application.StartupPath, dbFileName); 

            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
                MessageBox.Show($"Database created at:\n{databasePath}");
            }

            const string createSQLTableQuery = @"
                CREATE TABLE IF NOT EXISTS EscapeRoomUsers (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Email TEXT NOT NULL,
                    HashedPassword TEXT NOT NULL,
                    Salt TEXT NOT NULL
                );";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(createSQLTableQuery, connection))
                    command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
