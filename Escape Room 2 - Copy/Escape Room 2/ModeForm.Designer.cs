namespace Escape_Room_2
{
    partial class ModeForm
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
            this.bnServer = new System.Windows.Forms.Button();
            this.bnClient = new System.Windows.Forms.Button();
            this.labelTitleMode1 = new System.Windows.Forms.Label();
            this.labelServerEx = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitleMode2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bnServer
            // 
            this.bnServer.BackColor = System.Drawing.Color.SaddleBrown;
            this.bnServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnServer.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnServer.ForeColor = System.Drawing.Color.SandyBrown;
            this.bnServer.Location = new System.Drawing.Point(109, 169);
            this.bnServer.Margin = new System.Windows.Forms.Padding(0);
            this.bnServer.Name = "bnServer";
            this.bnServer.Size = new System.Drawing.Size(230, 142);
            this.bnServer.TabIndex = 0;
            this.bnServer.Text = "Big Boss [Server]";
            this.bnServer.UseVisualStyleBackColor = false;
            this.bnServer.Click += new System.EventHandler(this.bnServer_Click);
            // 
            // bnClient
            // 
            this.bnClient.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.bnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnClient.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnClient.ForeColor = System.Drawing.Color.DarkKhaki;
            this.bnClient.Location = new System.Drawing.Point(465, 169);
            this.bnClient.Name = "bnClient";
            this.bnClient.Size = new System.Drawing.Size(230, 142);
            this.bnClient.TabIndex = 1;
            this.bnClient.Text = "Player [Client]";
            this.bnClient.UseVisualStyleBackColor = false;
            this.bnClient.Click += new System.EventHandler(this.bnClient_Click);
            // 
            // labelTitleMode1
            // 
            this.labelTitleMode1.AutoSize = true;
            this.labelTitleMode1.BackColor = System.Drawing.Color.BurlyWood;
            this.labelTitleMode1.Font = new System.Drawing.Font("Perpetua", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleMode1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelTitleMode1.Location = new System.Drawing.Point(271, 46);
            this.labelTitleMode1.Name = "labelTitleMode1";
            this.labelTitleMode1.Size = new System.Drawing.Size(263, 42);
            this.labelTitleMode1.TabIndex = 2;
            this.labelTitleMode1.Text = "Choose a Role - ";
            this.labelTitleMode1.Click += new System.EventHandler(this.labelTitleMode_Click);
            // 
            // labelServerEx
            // 
            this.labelServerEx.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerEx.Location = new System.Drawing.Point(84, 331);
            this.labelServerEx.Name = "labelServerEx";
            this.labelServerEx.Size = new System.Drawing.Size(328, 107);
            this.labelServerEx.TabIndex = 3;
            this.labelServerEx.Text = "Only one of you can be the server. If you are, you can\'t play. But you can be the" +
    " Big Boss!";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 107);
            this.label1.TabIndex = 4;
            this.label1.Text = "A player in the game! A mysterious adventure is waiting for you!";
            // 
            // labelTitleMode2
            // 
            this.labelTitleMode2.AutoSize = true;
            this.labelTitleMode2.BackColor = System.Drawing.Color.BurlyWood;
            this.labelTitleMode2.Font = new System.Drawing.Font("Perpetua", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleMode2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelTitleMode2.Location = new System.Drawing.Point(173, 100);
            this.labelTitleMode2.Name = "labelTitleMode2";
            this.labelTitleMode2.Size = new System.Drawing.Size(476, 42);
            this.labelTitleMode2.TabIndex = 5;
            this.labelTitleMode2.Text = "who do you want to be today?";
            // 
            // ModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTitleMode2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelServerEx);
            this.Controls.Add(this.labelTitleMode1);
            this.Controls.Add(this.bnClient);
            this.Controls.Add(this.bnServer);
            this.Name = "ModeForm";
            this.Text = "ModeForm";
            this.Load += new System.EventHandler(this.ModeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnServer;
        private System.Windows.Forms.Button bnClient;
        private System.Windows.Forms.Label labelTitleMode1;
        private System.Windows.Forms.Label labelServerEx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitleMode2;
    }
}