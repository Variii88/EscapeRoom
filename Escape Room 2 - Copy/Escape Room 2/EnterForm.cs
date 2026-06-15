using System;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;

namespace Escape_Room_2
{
    public partial class EnterForm : Form
    {
        private GameConnection connection;

        public EnterForm(GameConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            connection.ServerDisconnected += HandleServerDisconnect; //subscribe to server disconnection
        }

        
        private void HandleServerDisconnect()
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show("Server disconnected.");
                new EscapeRoomForm().Show();
                this.Close();
            }));
        }



        private void bnEnter_Click(object sender, EventArgs e)
        {
            connection.ServerDisconnected -= HandleServerDisconnect;
            InstructionsForm instructionsForm = new InstructionsForm(connection);
            instructionsForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection.ServerDisconnected -= HandleServerDisconnect;
            connection.Close();
            base.OnFormClosing(e);
        }
    }
}
