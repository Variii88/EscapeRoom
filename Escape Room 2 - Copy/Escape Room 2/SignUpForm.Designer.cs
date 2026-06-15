namespace Escape_Room_2
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelSignUp = new System.Windows.Forms.Label();
            this.bnSignUp = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbUsername
            // 
            this.txtbUsername.BackColor = System.Drawing.Color.Peru;
            this.txtbUsername.Location = new System.Drawing.Point(301, 127);
            this.txtbUsername.Multiline = true;
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(184, 35);
            this.txtbUsername.TabIndex = 0;
            // 
            // txtbEmail
            // 
            this.txtbEmail.BackColor = System.Drawing.Color.Peru;
            this.txtbEmail.Location = new System.Drawing.Point(296, 219);
            this.txtbEmail.Multiline = true;
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(202, 30);
            this.txtbEmail.TabIndex = 1;
            // 
            // txtbPassword
            // 
            this.txtbPassword.BackColor = System.Drawing.Color.Peru;
            this.txtbPassword.Location = new System.Drawing.Point(296, 299);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '•';
            this.txtbPassword.Size = new System.Drawing.Size(202, 26);
            this.txtbPassword.TabIndex = 2;
            this.txtbPassword.UseSystemPasswordChar = true;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelUsername.Font = new System.Drawing.Font("Juice ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(327, 83);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(123, 41);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelEmail.Font = new System.Drawing.Font("Juice ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(351, 165);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(81, 41);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelPassword.Font = new System.Drawing.Font("Juice ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(328, 252);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(123, 41);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password";
            // 
            // labelSignUp
            // 
            this.labelSignUp.AutoSize = true;
            this.labelSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelSignUp.Font = new System.Drawing.Font("Snap ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignUp.Location = new System.Drawing.Point(274, 27);
            this.labelSignUp.Name = "labelSignUp";
            this.labelSignUp.Size = new System.Drawing.Size(224, 51);
            this.labelSignUp.TabIndex = 6;
            this.labelSignUp.Text = "Sign Up:";
            // 
            // bnSignUp
            // 
            this.bnSignUp.BackColor = System.Drawing.Color.Maroon;
            this.bnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSignUp.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSignUp.Location = new System.Drawing.Point(301, 331);
            this.bnSignUp.Name = "bnSignUp";
            this.bnSignUp.Size = new System.Drawing.Size(167, 47);
            this.bnSignUp.TabIndex = 8;
            this.bnSignUp.Text = "Sign Up";
            this.bnSignUp.UseVisualStyleBackColor = false;
            this.bnSignUp.Click += new System.EventHandler(this.bnSignUp_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelLogin.Font = new System.Drawing.Font("MingLiU_MSCS-ExtB", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.Location = new System.Drawing.Point(345, 394);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(87, 28);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Login";
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(795, 461);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.bnSignUp);
            this.Controls.Add(this.labelSignUp);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbEmail);
            this.Controls.Add(this.txtbUsername);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelSignUp;
        private System.Windows.Forms.Button bnSignUp;
        private System.Windows.Forms.Label labelLogin;
    }
}