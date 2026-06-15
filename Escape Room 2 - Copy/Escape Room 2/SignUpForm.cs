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
            string username = txtbUsername.Text;
            string email = txtbEmail.Text;
            string password = txtbPassword.Text;
            string hashedPassword = PlayerHelper.HashPassword(password);

            if (!email.Contains("@"))
            {
                MessageBox.Show("Email must contain @");
                return;
            }

            PlayerInfo playerInfo = new PlayerInfo(username, email, hashedPassword, GameProtocol.Signup);

            string response;
            GameConnection connection = PlayerHelper.ConnectToServer(playerInfo, serverIP, out response);

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
