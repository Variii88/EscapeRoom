namespace Escape_Room_2
{
    partial class Room1
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
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtbMessage = new System.Windows.Forms.TextBox();
            this.bnSend = new System.Windows.Forms.Button();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbAnswer = new System.Windows.Forms.TextBox();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.bnReveal = new System.Windows.Forms.Button();
            this.pbHint = new System.Windows.Forms.PictureBox();
            this.pbVenus = new System.Windows.Forms.PictureBox();
            this.pbMars = new System.Windows.Forms.PictureBox();
            this.pbSaturn = new System.Windows.Forms.PictureBox();
            this.labelVenus = new System.Windows.Forms.Label();
            this.labelMars = new System.Windows.Forms.Label();
            this.labelSaturn = new System.Windows.Forms.Label();
            this.pnlImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaturn)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.Wheat;
            this.rtbChat.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChat.ForeColor = System.Drawing.Color.Black;
            this.rtbChat.Location = new System.Drawing.Point(633, 0);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(198, 387);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // txtbMessage
            // 
            this.txtbMessage.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbMessage.Location = new System.Drawing.Point(633, 398);
            this.txtbMessage.Name = "txtbMessage";
            this.txtbMessage.Size = new System.Drawing.Size(98, 29);
            this.txtbMessage.TabIndex = 1;
            // 
            // bnSend
            // 
            this.bnSend.BackColor = System.Drawing.Color.Sienna;
            this.bnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSend.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSend.ForeColor = System.Drawing.Color.White;
            this.bnSend.Location = new System.Drawing.Point(734, 395);
            this.bnSend.Margin = new System.Windows.Forms.Padding(0);
            this.bnSend.Name = "bnSend";
            this.bnSend.Size = new System.Drawing.Size(85, 35);
            this.bnSend.TabIndex = 2;
            this.bnSend.Text = "Send";
            this.bnSend.UseVisualStyleBackColor = false;
            this.bnSend.Click += new System.EventHandler(this.bnSend_Click);
            // 
            // labelQuestion
            // 
            this.labelQuestion.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.ForeColor = System.Drawing.Color.Maroon;
            this.labelQuestion.Location = new System.Drawing.Point(184, 0);
            this.labelQuestion.MaximumSize = new System.Drawing.Size(700, 150);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(443, 94);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "In ancient times I rose at dawn and night, a wandering star that guided sailors r" +
    "ight.";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlImages
            // 
            this.pnlImages.Controls.Add(this.panel1);
            this.pnlImages.Location = new System.Drawing.Point(0, 85);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(303, 408);
            this.pnlImages.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(104, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // txtbAnswer
            // 
            this.txtbAnswer.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAnswer.Location = new System.Drawing.Point(309, 344);
            this.txtbAnswer.Name = "txtbAnswer";
            this.txtbAnswer.Size = new System.Drawing.Size(137, 27);
            this.txtbAnswer.TabIndex = 5;
            // 
            // bnSubmit
            // 
            this.bnSubmit.BackColor = System.Drawing.Color.Brown;
            this.bnSubmit.Font = new System.Drawing.Font("Kristen ITC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSubmit.ForeColor = System.Drawing.Color.Salmon;
            this.bnSubmit.Location = new System.Drawing.Point(337, 377);
            this.bnSubmit.Name = "bnSubmit";
            this.bnSubmit.Size = new System.Drawing.Size(96, 71);
            this.bnSubmit.TabIndex = 6;
            this.bnSubmit.Text = "Submit";
            this.bnSubmit.UseVisualStyleBackColor = false;
            this.bnSubmit.Click += new System.EventHandler(this.bnSubmit_Click);
            // 
            // bnReveal
            // 
            this.bnReveal.BackColor = System.Drawing.Color.Maroon;
            this.bnReveal.Font = new System.Drawing.Font("Lucida Handwriting", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnReveal.ForeColor = System.Drawing.Color.RosyBrown;
            this.bnReveal.Location = new System.Drawing.Point(479, 366);
            this.bnReveal.Name = "bnReveal";
            this.bnReveal.Size = new System.Drawing.Size(98, 82);
            this.bnReveal.TabIndex = 7;
            this.bnReveal.Text = "Reveal Answer";
            this.bnReveal.UseVisualStyleBackColor = false;
            this.bnReveal.Visible = false;
            this.bnReveal.Click += new System.EventHandler(this.bnReveal_Click);
            // 
            // pbHint
            // 
            this.pbHint.Location = new System.Drawing.Point(309, 167);
            this.pbHint.Name = "pbHint";
            this.pbHint.Size = new System.Drawing.Size(114, 150);
            this.pbHint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHint.TabIndex = 8;
            this.pbHint.TabStop = false;
            // 
            // pbVenus
            // 
            this.pbVenus.Location = new System.Drawing.Point(326, 97);
            this.pbVenus.Name = "pbVenus";
            this.pbVenus.Size = new System.Drawing.Size(147, 87);
            this.pbVenus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVenus.TabIndex = 9;
            this.pbVenus.TabStop = false;
            // 
            // pbMars
            // 
            this.pbMars.Location = new System.Drawing.Point(337, 190);
            this.pbMars.Name = "pbMars";
            this.pbMars.Size = new System.Drawing.Size(123, 100);
            this.pbMars.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMars.TabIndex = 10;
            this.pbMars.TabStop = false;
            // 
            // pbSaturn
            // 
            this.pbSaturn.Location = new System.Drawing.Point(329, 296);
            this.pbSaturn.Name = "pbSaturn";
            this.pbSaturn.Size = new System.Drawing.Size(144, 107);
            this.pbSaturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSaturn.TabIndex = 11;
            this.pbSaturn.TabStop = false;
           
            // 
            // labelVenus
            // 
            this.labelVenus.AutoSize = true;
            this.labelVenus.Font = new System.Drawing.Font("Script MT Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVenus.Location = new System.Drawing.Point(496, 123);
            this.labelVenus.Name = "labelVenus";
            this.labelVenus.Size = new System.Drawing.Size(56, 34);
            this.labelVenus.TabIndex = 12;
            this.labelVenus.Text = "{V}";
            // 
            // labelMars
            // 
            this.labelMars.AutoSize = true;
            this.labelMars.Font = new System.Drawing.Font("Script MT Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMars.Location = new System.Drawing.Point(487, 225);
            this.labelMars.Name = "labelMars";
            this.labelMars.Size = new System.Drawing.Size(65, 34);
            this.labelMars.TabIndex = 13;
            this.labelMars.Text = "{M}";
            // 
            // labelSaturn
            // 
            this.labelSaturn.AutoSize = true;
            this.labelSaturn.Font = new System.Drawing.Font("Script MT Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaturn.Location = new System.Drawing.Point(496, 318);
            this.labelSaturn.Name = "labelSaturn";
            this.labelSaturn.Size = new System.Drawing.Size(53, 34);
            this.labelSaturn.TabIndex = 14;
            this.labelSaturn.Text = "{S}";
            
            // 
            // Room1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(828, 455);
            this.Controls.Add(this.txtbAnswer);
            this.Controls.Add(this.bnSubmit);
            this.Controls.Add(this.labelSaturn);
            this.Controls.Add(this.labelMars);
            this.Controls.Add(this.labelVenus);
            this.Controls.Add(this.pbSaturn);
            this.Controls.Add(this.pbMars);
            this.Controls.Add(this.pbVenus);
            this.Controls.Add(this.pbHint);
            this.Controls.Add(this.bnReveal);
            this.Controls.Add(this.pnlImages);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.bnSend);
            this.Controls.Add(this.txtbMessage);
            this.Controls.Add(this.rtbChat);
            this.Name = "Room1";
            this.Text = "Room1";
            this.pnlImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtbMessage;
        private System.Windows.Forms.Button bnSend;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.TextBox txtbAnswer;
        private System.Windows.Forms.Button bnSubmit;
        private System.Windows.Forms.Button bnReveal;
        private System.Windows.Forms.PictureBox pbHint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbVenus;
        private System.Windows.Forms.PictureBox pbMars;
        private System.Windows.Forms.PictureBox pbSaturn;
        private System.Windows.Forms.Label labelVenus;
        private System.Windows.Forms.Label labelMars;
        private System.Windows.Forms.Label labelSaturn;
    }
}