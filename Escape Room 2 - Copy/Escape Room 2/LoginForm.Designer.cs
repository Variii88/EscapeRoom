namespace Escape_Room_2
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelSignup = new System.Windows.Forms.Label();
            this.bnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Peru;
            this.labelPassword.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(319, 192);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(145, 34);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Peru;
            this.labelUsername.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelUsername.Location = new System.Drawing.Point(312, 85);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(152, 34);
            this.labelUsername.TabIndex = 9;
            this.labelUsername.Text = "Username";
            // 
            // txtbPassword
            // 
            this.txtbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtbPassword.Location = new System.Drawing.Point(294, 245);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(202, 26);
            this.txtbPassword.TabIndex = 8;
            this.txtbPassword.UseSystemPasswordChar = true;
            // 
            // txtbUsername
            // 
            this.txtbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtbUsername.Location = new System.Drawing.Point(289, 132);
            this.txtbUsername.Multiline = true;
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(202, 37);
            this.txtbUsername.TabIndex = 6;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Sienna;
            this.labelLogin.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.Black;
            this.labelLogin.Location = new System.Drawing.Point(286, 22);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(215, 45);
            this.labelLogin.TabIndex = 12;
            this.labelLogin.Text = "Login:";
            // 
            // labelSignup
            // 
            this.labelSignup.AutoSize = true;
            this.labelSignup.BackColor = System.Drawing.Color.Peru;
            this.labelSignup.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignup.Location = new System.Drawing.Point(337, 356);
            this.labelSignup.Name = "labelSignup";
            this.labelSignup.Size = new System.Drawing.Size(116, 37);
            this.labelSignup.TabIndex = 13;
            this.labelSignup.Text = "Sign Up";
            this.labelSignup.Click += new System.EventHandler(this.labelSignup_Click);
            // 
            // bnLogin
            // 
            this.bnLogin.BackColor = System.Drawing.Color.Maroon;
            this.bnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnLogin.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnLogin.ForeColor = System.Drawing.Color.Black;
            this.bnLogin.Location = new System.Drawing.Point(308, 286);
            this.bnLogin.Name = "bnLogin";
            this.bnLogin.Size = new System.Drawing.Size(173, 51);
            this.bnLogin.TabIndex = 14;
            this.bnLogin.Text = "Login";
            this.bnLogin.UseVisualStyleBackColor = false;
            this.bnLogin.Click += new System.EventHandler(this.bnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(803, 457);
            this.Controls.Add(this.bnLogin);
            this.Controls.Add(this.labelSignup);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbUsername);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelSignup;
        private System.Windows.Forms.Button bnLogin;
    }
}