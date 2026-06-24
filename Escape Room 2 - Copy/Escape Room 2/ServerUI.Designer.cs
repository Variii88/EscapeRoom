namespace Escape_Room_2
{
    partial class ServerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerUI));
            this.bnOpenDB = new System.Windows.Forms.Button();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.labelServerTitle = new System.Windows.Forms.Label();
            this.bnInitDB = new System.Windows.Forms.Button();
            this.bnBehaviour = new System.Windows.Forms.Button();
            this.bnReset = new System.Windows.Forms.Button();
            this.bnHAHA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnOpenDB
            // 
            this.bnOpenDB.BackColor = System.Drawing.Color.Sienna;
            this.bnOpenDB.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnOpenDB.ForeColor = System.Drawing.Color.White;
            this.bnOpenDB.Location = new System.Drawing.Point(44, 311);
            this.bnOpenDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bnOpenDB.Name = "bnOpenDB";
            this.bnOpenDB.Size = new System.Drawing.Size(122, 74);
            this.bnOpenDB.TabIndex = 0;
            this.bnOpenDB.Text = "Open Database";
            this.bnOpenDB.UseVisualStyleBackColor = false;
            this.bnOpenDB.Click += new System.EventHandler(this.bnOpenDB_Click);
            // 
            // rtbLogs
            // 
            this.rtbLogs.BackColor = System.Drawing.Color.BurlyWood;
            this.rtbLogs.Location = new System.Drawing.Point(162, 126);
            this.rtbLogs.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(478, 184);
            this.rtbLogs.TabIndex = 1;
            this.rtbLogs.Text = "";
            // 
            // labelServerTitle
            // 
            this.labelServerTitle.AutoSize = true;
            this.labelServerTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelServerTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelServerTitle.Font = new System.Drawing.Font("Modern No. 20", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelServerTitle.Location = new System.Drawing.Point(196, 20);
            this.labelServerTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelServerTitle.Name = "labelServerTitle";
            this.labelServerTitle.Size = new System.Drawing.Size(425, 45);
            this.labelServerTitle.TabIndex = 2;
            this.labelServerTitle.Text = "Server - The Big Boss";
            // 
            // bnInitDB
            // 
            this.bnInitDB.BackColor = System.Drawing.Color.Sienna;
            this.bnInitDB.Font = new System.Drawing.Font("Modern No. 20", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnInitDB.ForeColor = System.Drawing.Color.White;
            this.bnInitDB.Location = new System.Drawing.Point(134, 397);
            this.bnInitDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bnInitDB.Name = "bnInitDB";
            this.bnInitDB.Size = new System.Drawing.Size(130, 75);
            this.bnInitDB.TabIndex = 3;
            this.bnInitDB.Text = "Clear Database";
            this.bnInitDB.UseVisualStyleBackColor = false;
            this.bnInitDB.Click += new System.EventHandler(this.bnClearDB_Click);
            // 
            // bnBehaviour
            // 
            this.bnBehaviour.BackColor = System.Drawing.Color.Sienna;
            this.bnBehaviour.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnBehaviour.ForeColor = System.Drawing.Color.White;
            this.bnBehaviour.Location = new System.Drawing.Point(516, 380);
            this.bnBehaviour.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bnBehaviour.Name = "bnBehaviour";
            this.bnBehaviour.Size = new System.Drawing.Size(124, 92);
            this.bnBehaviour.TabIndex = 4;
            this.bnBehaviour.Text = "Broadcast Behaviour Message";
            this.bnBehaviour.UseVisualStyleBackColor = false;
            this.bnBehaviour.Click += new System.EventHandler(this.bnBehaviour_Click);
            // 
            // bnReset
            // 
            this.bnReset.BackColor = System.Drawing.Color.Sienna;
            this.bnReset.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnReset.ForeColor = System.Drawing.Color.White;
            this.bnReset.Location = new System.Drawing.Point(329, 329);
            this.bnReset.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bnReset.Name = "bnReset";
            this.bnReset.Size = new System.Drawing.Size(94, 79);
            this.bnReset.TabIndex = 5;
            this.bnReset.Text = "Reset Game";
            this.bnReset.UseVisualStyleBackColor = false;
            this.bnReset.Click += new System.EventHandler(this.bnReset_Click);
            // 
            // bnHAHA
            // 
            this.bnHAHA.BackColor = System.Drawing.Color.Sienna;
            this.bnHAHA.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnHAHA.ForeColor = System.Drawing.Color.White;
            this.bnHAHA.Location = new System.Drawing.Point(678, 324);
            this.bnHAHA.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bnHAHA.Name = "bnHAHA";
            this.bnHAHA.Size = new System.Drawing.Size(106, 50);
            this.bnHAHA.TabIndex = 6;
            this.bnHAHA.Text = "HAHAHA!";
            this.bnHAHA.UseVisualStyleBackColor = false;
            this.bnHAHA.Click += new System.EventHandler(this.bnHAHA_Click);
            // 
            // ServerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(798, 502);
            this.Controls.Add(this.bnHAHA);
            this.Controls.Add(this.bnReset);
            this.Controls.Add(this.bnBehaviour);
            this.Controls.Add(this.bnInitDB);
            this.Controls.Add(this.labelServerTitle);
            this.Controls.Add(this.rtbLogs);
            this.Controls.Add(this.bnOpenDB);
            this.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "ServerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerUI";
            this.Load += new System.EventHandler(this.ServerUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOpenDB;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Label labelServerTitle;
        private System.Windows.Forms.Button bnInitDB;
        private System.Windows.Forms.Button bnBehaviour;
        private System.Windows.Forms.Button bnReset;
        private System.Windows.Forms.Button bnHAHA;
   
    }
}