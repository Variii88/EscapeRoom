using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Escape_Room_2.Game;
using Escape_Room_2.GameHelpers;


namespace Escape_Room_2
{
    public partial class Room1 : Form
    {
        private GameConnection connection;
        private bool switchingForms = false;
        
        public Room1(GameConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            connection.MessageReceived += HandleMessageReceived;
            connection.ServerDisconnected += HandleServerDisconnect; 
        }

        private void HandleMessageReceived(string message)
        {
            if (message.StartsWith(GameProtocol.Chat))
            {
                string chatMessage = message.Substring(GameProtocol.Chat.Length);
                Invoke((MethodInvoker)(() => rtbChat.AppendText(chatMessage + "\n")));
            }
            else if (message.StartsWith(GameProtocol.Puzzle))
            {
                Invoke((MethodInvoker)(() => LoadPuzzle(message)));
            }
            else if (message.StartsWith(GameProtocol.Hint))
            {
                string hintImage = message.Substring(GameProtocol.Hint.Length);
                Invoke((MethodInvoker)(() =>
                {
                    if (hintImage != "")
                    {
                        pbHint.Image = LoadImage(hintImage);
                        pbHint.Visible = true;
                    }
                }));
            }
            else if (message == GameProtocol.Next)
            {
                Invoke((MethodInvoker)(() =>
                {
                    labelQuestion.Text = "";
                    pnlImages.Controls.Clear();
                    pbHint.Visible = false;
                    pbHint.Image = null;
                    bnReveal.Visible = false;
                    txtbAnswer.Clear();
                }));
            }
            else if (message == GameProtocol.ShowReveal)
            {
                Invoke((MethodInvoker)(() => bnReveal.Visible = true));
            }
            else if (message == GameProtocol.HideReveal)
            {
                Invoke((MethodInvoker)(() => bnReveal.Visible = false));
            }
            else if (message == GameProtocol.GameOver)
            {
                Invoke((MethodInvoker)(() =>
                {
                    connection.MessageReceived -= HandleMessageReceived;
                    string result = message.Contains("WIN") ? "You Won! 🎉" : "You Lost!";
                    MessageBox.Show($"Game Over! {result} Thanks for playing!\n Now you got the key and you can get out of the castle!!!");
                    EscapeRoomForm escapeRoomForm = new EscapeRoomForm();
                    escapeRoomForm.Show();
                    this.Close();
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
                    MessageBox.Show($"{username} has disconnected. Returning to the beginning.");
                    new EscapeRoomForm().Show();
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


        private void LoadPuzzle(string message)
        {
            string content = message.Substring(GameProtocol.Puzzle.Length);
            string[] parts = content.Split('|');
            string type = parts[0];
            string question = parts[1];
            string questionLocation = parts[2];
            string[] images = parts[3].Split(',');

            txtbAnswer.Visible = true;
            bnSubmit.Visible = true;
            pbHint.Visible = false;
            pbHint.Image = null;
            pbVenus.Visible = false;
            pbMars.Visible = false;
            pbSaturn.Visible = false;
            labelVenus.Visible = false;
            labelMars.Visible = false;
            labelSaturn.Visible = false;
            txtbAnswer.Clear();
            pnlImages.Controls.Clear();

            if (questionLocation == "SCREEN")
                labelQuestion.Text = question;
            else if (questionLocation == "CHAT")
            {
                labelQuestion.Text = "";
                rtbChat.AppendText("Server: " + question + "\n");
            }

            foreach (string imgPath in images)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 200;
                pb.Height = 200;
                pb.Image = LoadImage(imgPath);
                pnlImages.Controls.Add(pb);
            }

            if (type == "CHOICE" && parts.Length > 4)
            {
                string[] choices = parts[4].Substring("CHOICES:".Length).Split(',');

                pbVenus.Image = LoadImage(choices[0]);
                pbVenus.Visible = true;
                pbVenus.Tag = choices[0];
                pbVenus.Click += Choice_Click;

                pbMars.Image = LoadImage(choices[1]);
                pbMars.Visible = true;
                pbMars.Tag = choices[1];
                pbMars.Click += Choice_Click;

                pbSaturn.Image = LoadImage(choices[2]);
                pbSaturn.Visible = true;
                pbSaturn.Tag = choices[2];
                pbSaturn.Click += Choice_Click;

                labelVenus.Visible = true;
                labelMars.Visible = true;
                labelSaturn.Visible = true;

                txtbAnswer.Visible = false;
                bnSubmit.Visible = false;
            }
        }

        private Image LoadImage(string relativePath)
        {
            string fullPath = Path.Combine(Application.StartupPath, relativePath);
            byte[] bytes = File.ReadAllBytes(fullPath);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            string imagePath = pb.Tag.ToString();
            string chosen = Path.GetFileNameWithoutExtension(imagePath);
            connection.Send($"{GameProtocol.Answer}{connection.Username}:{chosen}");
        }


        private void bnSend_Click(object sender, EventArgs e)
        {
            string message = txtbMessage.Text;
            if (message == "") return;
            if (message.Length > 200)
            {
                MessageBox.Show("The message is too long.");
                return;
            }
            connection.Send($"{GameProtocol.ChatMsg}{connection.Username}:{message}");
            txtbMessage.Clear();
        }


        private void bnSubmit_Click(object sender, EventArgs e)
        {
            string answer = txtbAnswer.Text;
            if (answer == "") return;
            if (answer.Length > 100)
            {
                MessageBox.Show("Answer cannot exceed 100 characters.");
                return;
            }
            connection.Send($"{GameProtocol.Answer}{connection.Username}:{answer}");
            txtbAnswer.Clear();
        }


        private void bnReveal_Click(object sender, EventArgs e)
        {
            connection.Send(GameProtocol.Reveal);
            bnReveal.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection.ServerDisconnected -= HandleServerDisconnect;
            connection.MessageReceived -= HandleMessageReceived;
            if(!switchingForms)
                connection.Close();
            base.OnFormClosing(e);
        }
    }
}
