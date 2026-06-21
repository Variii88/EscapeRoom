using System.Threading.Tasks;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;

namespace Escape_Room_2
{
    public partial class WaitingRoomForm : Form
    {
        private GameConnection connection;

        public WaitingRoomForm(GameConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            connection.MessageReceived += HandleMessageReceived;
            connection.ServerDisconnected += HandleServerDisconnect; //subscribe to server disconnection
            Task.Delay(1000).ContinueWith(_ => connection.Send(GameProtocol.RequestCount));
        }


        private void HandleMessageReceived(string message)
        {
            if (message.StartsWith(GameProtocol.Players))
            {
                string labelText = message.Substring(GameProtocol.Players.Length);
                Invoke((MethodInvoker)(() => labelConnectedPlayers.Text = labelText));
            }
            else if (message == GameProtocol.Start)
            {
                connection.MessageReceived -= HandleMessageReceived;
                Invoke((MethodInvoker)(() =>
                {
                    EnterForm enterForm = new EnterForm(connection);
                    enterForm.Show();
                    this.Hide();
                }));
            }
        }



        private void HandleServerDisconnect()
        {
            Invoke((MethodInvoker)(() =>
            {
                connection.ServerDisconnected -= HandleServerDisconnect;
                connection.MessageReceived -= HandleMessageReceived;
                connection.Close();
                MessageBox.Show("Server disconnected.");
                new EscapeRoomForm().Show();
                this.Close();
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection.ServerDisconnected -= HandleServerDisconnect;
            connection.MessageReceived -= HandleMessageReceived;
            connection.Close();
            base.OnFormClosing(e);
        }

        private void WaitingRoomForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
