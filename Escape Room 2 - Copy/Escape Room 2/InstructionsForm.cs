using System;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;

namespace Escape_Room_2
{
    public partial class InstructionsForm : Form
    {
        private GameConnection connection;
        private bool switchingForms = false;

        public InstructionsForm(GameConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            connection.MessageReceived += HandleMessageReceived;
            connection.ServerDisconnected += HandleServerDisconnect; 
        }

        private void HandleMessageReceived(string message)
        {
            if (message == GameProtocol.StartGame)
            {
                connection.MessageReceived -= HandleMessageReceived;
                connection.ServerDisconnected -= HandleServerDisconnect;
                Invoke((MethodInvoker)(() =>
                {
                    Room1 room1 = new Room1(connection);
                    room1.Show();
                    this.Hide();
                }));
            }
            else if (message.StartsWith(GameProtocol.PlayerDisconnected))
            {
                string username = message.Substring(GameProtocol.PlayerDisconnected.Length);
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

        private void HandleServerDisconnect()
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show("Server disconnected.");
                new EscapeRoomForm().Show();
                this.Close();
            }));
        }

        private void bnBegin_Click(object sender, EventArgs e)
        {
            connection.Send(GameProtocol.Ready);
            bnBegin.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection.ServerDisconnected -= HandleServerDisconnect;
            connection.MessageReceived -= HandleMessageReceived;
            if (!switchingForms) 
                connection.Close();
            base.OnFormClosing(e);
        }
    }
}
