namespace Escape_Room_2
{
    partial class WaitingRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingRoomForm));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelNameGame = new System.Windows.Forms.Label();
            this.labelWaiting = new System.Windows.Forms.Label();
            this.labelConnectedPlayers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Chocolate;
            this.labelWelcome.Font = new System.Drawing.Font("Snap ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(196, 79);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(379, 51);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Waiting Room:)";
            // 
            // labelNameGame
            // 
            this.labelNameGame.AutoSize = true;
            this.labelNameGame.BackColor = System.Drawing.Color.Chocolate;
            this.labelNameGame.Font = new System.Drawing.Font("Viner Hand ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameGame.Location = new System.Drawing.Point(97, 147);
            this.labelNameGame.Name = "labelNameGame";
            this.labelNameGame.Size = new System.Drawing.Size(585, 65);
            this.labelNameGame.TabIndex = 1;
            this.labelNameGame.Text = "Haunted Castle Escape Room";
            // 
            // labelWaiting
            // 
            this.labelWaiting.AutoSize = true;
            this.labelWaiting.BackColor = System.Drawing.Color.Chocolate;
            this.labelWaiting.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaiting.Location = new System.Drawing.Point(149, 228);
            this.labelWaiting.Name = "labelWaiting";
            this.labelWaiting.Size = new System.Drawing.Size(479, 30);
            this.labelWaiting.TabIndex = 2;
            this.labelWaiting.Text = "waiting for the other players to connect...";
            // 
            // labelConnectedPlayers
            // 
            this.labelConnectedPlayers.AutoSize = true;
            this.labelConnectedPlayers.BackColor = System.Drawing.Color.Chocolate;
            this.labelConnectedPlayers.Font = new System.Drawing.Font("Juice ITC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectedPlayers.Location = new System.Drawing.Point(314, 282);
            this.labelConnectedPlayers.Name = "labelConnectedPlayers";
            this.labelConnectedPlayers.Size = new System.Drawing.Size(198, 37);
            this.labelConnectedPlayers.TabIndex = 3;
            this.labelConnectedPlayers.Text = "1/3 players joined";
            // 
            // WaitingRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(806, 474);
            this.Controls.Add(this.labelConnectedPlayers);
            this.Controls.Add(this.labelWaiting);
            this.Controls.Add(this.labelNameGame);
            this.Controls.Add(this.labelWelcome);
            this.Name = "WaitingRoomForm";
            this.Text = "WaitingRoomForm";
            this.Load += new System.EventHandler(this.WaitingRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelNameGame;
        private System.Windows.Forms.Label labelWaiting;
        private System.Windows.Forms.Label labelConnectedPlayers;
    }
}