using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escape_Room_2.GameHelpers;
using Escape_Room_2.ServerER;

namespace Escape_Room_2
{
    public partial class ModeForm : Form
    {
        #region Properties
        private Timer checkTimer;
        #endregion

        public ModeForm()
        {
            InitializeComponent();
        }

        private async void bnServer_Click(object sender, EventArgs e)
        {
            string serverIP = await UDPDiscovery.FindServerAsync(2000);
            if (serverIP != null)
            {
                MessageBox.Show("Another player is already the Big Boss(server). You can only be a Player now!");
                return;
            }
            ServerUI serverForm = new ServerUI();
            serverForm.Show();
            this.Hide();
        }

        private async void bnClient_Click(object sender, EventArgs e)
        {
            string serverIP = await UDPDiscovery.FindServerAsync(3000);

            if (serverIP == null)
            {
                MessageBox.Show("There is no Big Boss(server). You can only be a Player when the Big Boss is chosen");
                return;
            }
            
            LoginForm loginForm = new LoginForm(serverIP);
            loginForm.Show();
            this.Hide();
        }
    }
}
