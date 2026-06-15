using System;
using System.Windows.Forms;

namespace Escape_Room_2
{
    public partial class EscapeRoomForm : Form
    {
        public EscapeRoomForm()
        {
            InitializeComponent();
        }

        private void bnStartGame_Click(object sender, EventArgs e)
        {
            ModeForm modeForm = new ModeForm();
            modeForm.Show();
            this.Hide(); 
        }
    }
}
