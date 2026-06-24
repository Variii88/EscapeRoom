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
            if (txtbUsername.Text.Trim() == "" || txtbPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (txtbUsername.Text.Length > 20)
            {
                MessageBox.Show("Username cannot exceed 20 characters.");
                return;
            }
            if (txtbPassword.Text.Length < 4 || txtbPassword.Text.Length > 20)
            {
                MessageBox.Show("Password must be between 4 to 20 charachters.");
                return;
            }

            string username = txtbUsername.Text;
            string password = txtbPassword.Text;
            string hashedPassword = PlayerHelper.HashPassword(password);

            PlayerInfo playerInfo = new PlayerInfo(username, "", hashedPassword, GameProtocol.Login);

            string response;
            GameConnection connection = PlayerHelper.ConnectToServer(playerInfo, serverIP, out response);

           if (response == "GAME IN PROGRESS")
            {
                MessageBox.Show("A game is currently in progress. Please try again later.");
                return;
            }
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
