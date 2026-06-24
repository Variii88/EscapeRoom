using System;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Escape_Room_2
{
    public partial class EnterForm : Form
    {
        private GameConnection connection;
        private bool switchingForms = false;


        public EnterForm(GameConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            connection.ServerDisconnected += HandleServerDisconnect; 
            connection.MessageReceived += HandleMessageReceived;
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
            connection.MessageReceived -= HandleMessageReceived;
            InstructionsForm instructionsForm = new InstructionsForm(connection);
            instructionsForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection.ServerDisconnected -= HandleServerDisconnect;
            connection.MessageReceived -= HandleMessageReceived;
            if (!switchingForms) 
                connection.Close();
            base.OnFormClosing(e);
        }

        private void HandleMessageReceived(string message)
        {
            if (message.StartsWith(GameProtocol.PlayerDisconnected))
            {
                Invoke((MethodInvoker)(() =>
                {
                    switchingForms = true;
                    connection.ServerDisconnected -= HandleServerDisconnect;
                    connection.MessageReceived -= HandleMessageReceived;
                    MessageBox.Show("A player disconnected. Returning to the Waiting Room.");
                    new WaitingRoomForm(connection).Show();
                    this.Close();
                }));
            }
        }
    }
}
