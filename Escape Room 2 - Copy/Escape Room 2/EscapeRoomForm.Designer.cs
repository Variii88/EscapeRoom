namespace Escape_Room_2
{
    partial class EscapeRoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscapeRoomForm));
            this.bnStartGame = new System.Windows.Forms.Button();
            this.labelMainTitle1 = new System.Windows.Forms.Label();
            this.labelMainTitle2 = new System.Windows.Forms.Label();
            this.labelSubText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bnStartGame
            // 
            this.bnStartGame.BackColor = System.Drawing.Color.Maroon;
            this.bnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnStartGame.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnStartGame.ForeColor = System.Drawing.Color.IndianRed;
            this.bnStartGame.Location = new System.Drawing.Point(299, 342);
            this.bnStartGame.Name = "bnStartGame";
            this.bnStartGame.Size = new System.Drawing.Size(248, 78);
            this.bnStartGame.TabIndex = 0;
            this.bnStartGame.Text = "Start Game";
            this.bnStartGame.UseVisualStyleBackColor = false;
            this.bnStartGame.Click += new System.EventHandler(this.bnStartGame_Click);
            // 
            // labelMainTitle1
            // 
            this.labelMainTitle1.AutoSize = true;
            this.labelMainTitle1.BackColor = System.Drawing.Color.Transparent;
            this.labelMainTitle1.Font = new System.Drawing.Font("Perpetua", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainTitle1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelMainTitle1.Location = new System.Drawing.Point(203, 39);
            this.labelMainTitle1.Name = "labelMainTitle1";
            this.labelMainTitle1.Size = new System.Drawing.Size(439, 82);
            this.labelMainTitle1.TabIndex = 1;
            this.labelMainTitle1.Text = "Escape Room";
            this.labelMainTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMainTitle2
            // 
            this.labelMainTitle2.AutoSize = true;
            this.labelMainTitle2.BackColor = System.Drawing.Color.Transparent;
            this.labelMainTitle2.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainTitle2.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMainTitle2.Location = new System.Drawing.Point(65, 121);
            this.labelMainTitle2.Name = "labelMainTitle2";
            this.labelMainTitle2.Size = new System.Drawing.Size(709, 76);
            this.labelMainTitle2.TabIndex = 2;
            this.labelMainTitle2.Text = "Haunted Secret Castle Quest";
            this.labelMainTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubText
            // 
            this.labelSubText.BackColor = System.Drawing.Color.Transparent;
            this.labelSubText.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubText.ForeColor = System.Drawing.Color.DarkRed;
            this.labelSubText.Location = new System.Drawing.Point(128, 197);
            this.labelSubText.Name = "labelSubText";
            this.labelSubText.Size = new System.Drawing.Size(634, 120);
            this.labelSubText.TabIndex = 3;
            this.labelSubText.Text = "Welcome to the Escape Room: a game where you can enjoy mystery, solving questions" +
    " and puzzles in a wonderful company, with your friends!";
            this.labelSubText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EscapeRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(878, 454);
            this.Controls.Add(this.labelSubText);
            this.Controls.Add(this.labelMainTitle2);
            this.Controls.Add(this.labelMainTitle1);
            this.Controls.Add(this.bnStartGame);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EscapeRoomForm";
            this.Text = "EscapeRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnStartGame;
        private System.Windows.Forms.Label labelMainTitle1;
        private System.Windows.Forms.Label labelMainTitle2;
        private System.Windows.Forms.Label labelSubText;
    }
}

