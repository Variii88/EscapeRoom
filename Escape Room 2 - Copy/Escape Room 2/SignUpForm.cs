using System;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;
using Escape_Room_2.ServerER;


namespace Escape_Room_2
{
    public partial class SignUpForm : Form
    {
        #region Properties
        private string serverIP;
        bool hasLetter = false;
        bool hasDigit = false;

        #endregion
        public SignUpForm(string serverIP)
        {
            InitializeComponent();
            txtbPassword.UseSystemPasswordChar = true;
            this.serverIP = serverIP;
        }



        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

     
        private void bnSignUp_Click(object sender, EventArgs e)
        {
            
            if (txtbUsername.Text.Trim() == "" || txtbPassword.Text.Trim() == "" || txtbEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (txtbUsername.Text.Length > 20)
            {
                MessageBox.Show("Username cannot exceed 20 characters.");
                return;
            }
            if (txtbEmail.Text.Length > 20)
            {
                MessageBox.Show("Email cannot exceed 20 characters.");
                return;
            }
            if (!txtbEmail.Text.Contains("@") || !txtbEmail.Text.Contains(".com"))
            {
                MessageBox.Show("Please enter a valid email address. It must contain @ and .com");
                return;
            }
            if (txtbPassword.Text.Length < 4 || txtbPassword.Text.Length > 20)
            {
                MessageBox.Show("Password must be between 4 to 20 charachters.");
                return;
            }
            foreach (char c in txtbPassword.Text)
            {
                if (char.IsLetter(c))
                    hasLetter = true;

                if (char.IsDigit(c))
                    hasDigit = true;
            }

            if (!hasLetter || !hasDigit)
            {
                MessageBox.Show("Password must contain at least one letter and one digit.");
                return;
            }

            string username = txtbUsername.Text;
            string email = txtbEmail.Text;
            string password = txtbPassword.Text;
            string hashedPassword = PlayerHelper.HashPassword(password);

            PlayerInfo playerInfo = new PlayerInfo(username, email, hashedPassword, GameProtocol.Signup);
           
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
            else if (response == "EXISTS")
            {
                MessageBox.Show("Username already exists.");
            }
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {              
            LoginForm loginform = new LoginForm(serverIP);
            loginform.Show();
            this.Hide();
        }
    }
}
