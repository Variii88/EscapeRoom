using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;
using Escape_Room_2.ServerER;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Escape_Room_2
{
    public partial class ServerUI : Form
    {
        private Server server;
        public ServerUI()
        {
            InitializeComponent();
        }

 
        private void ServerUI_Load(object sender, EventArgs e)
        {
            server = new Server(this);
            Log("Server started successfully.");
        }


        private void bnOpenDB_Click(object sender, EventArgs e)
        {
            string databasebPath = Path.Combine(Application.StartupPath, "database.db");
            if (File.Exists(databasebPath))
                Process.Start(databasebPath);
            else
                MessageBox.Show("Database file not found.");
        }


        public void Log(string message)
        {
            if (rtbLogs.InvokeRequired)
                BeginInvoke((MethodInvoker)(() => rtbLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n")));
            else
                rtbLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            server.CloseAllConnections();
            server.StopUDPBroadcasting();
            EscapeRoomForm form = new EscapeRoomForm();
            form.Show();
            base.OnFormClosing(e);
        }

        private void bnReset_Click(object sender, EventArgs e)
        {
            server.ResetGame();
            Log("Game was reset by server.");
            this.Close();
        }

        private void bnHAHA_Click(object sender, EventArgs e)
        {
            Log("HAHAHA!");
        }

        private void bnBehaviour_Click(object sender, EventArgs e)
        {
            string message = "Respect your friends, the Big Boss is watching you!";
            server.BroadcastChat("Server", message);
        }

        private void bnClearDB_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(
    $"Data Source={Path.Combine(Application.StartupPath, "database.db")};Version=3;");
            {
                conn.Open();

                string query = "DELETE FROM EscapeRoomUsers";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            Log("Database cleared.");
        }
    }
}
