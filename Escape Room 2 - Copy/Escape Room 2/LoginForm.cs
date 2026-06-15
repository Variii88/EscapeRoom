using System;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;
using Escape_Room_2.ServerER;

namespace Escape_Room_2
{
    public partial class LoginForm : Form
    {
        private string serverIP;
        public LoginForm(string serverIP)
        {
            InitializeComponent();
            txtbPassword.UseSystemPasswordChar = true;
            this.serverIP = serverIP;
        }

        private void labelSignup_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(serverIP);
            signUpForm.Show();
            this.Hide();
        }

        private void bnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;
            string hashedPassword = PlayerHelper.HashPassword(password);

            PlayerInfo playerInfo = new PlayerInfo(username, "", hashedPassword, GameProtocol.Login);

            string response;
            GameConnection connection = PlayerHelper.ConnectToServer(playerInfo, serverIP, out response);

            if (response == "OK")
            {
                WaitingRoomForm waitingRoomForm = new WaitingRoomForm(connection);
                waitingRoomForm.Show();
                this.Hide();
            }
            else if (response == "WRONG")
            {
                MessageBox.Show("Wrong username or password.");
            }
            else if (response != null && response.StartsWith("BLOCKED:"))
            {
                string seconds = response.Substring("BLOCKED:".Length);
                MessageBox.Show($"Too many failed attempts. Try again in {seconds} seconds.");
            }
        }
    }
}
