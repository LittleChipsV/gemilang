namespace Gemilang.Views.Forms
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBoxEmail = new TextBox();
            buttonLogin = new Button();
            textBoxPassword = new TextBox();
            label3 = new Label();
            iconButtonVisibilityPassword = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.gambar_login;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(321, 507);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(406, 45);
            label1.Name = "label1";
            label1.Size = new Size(322, 91);
            label1.TabIndex = 1;
            label1.Text = "Login Gemilang Sekarang";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label2.Location = new Point(420, 189);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(420, 221);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Masukkan email";
            textBoxEmail.Size = new Size(284, 30);
            textBoxEmail.TabIndex = 3;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(255, 0, 92);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(477, 396);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(173, 44);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(420, 310);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Masukkan password";
            textBoxPassword.Size = new Size(252, 30);
            textBoxPassword.TabIndex = 8;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label3.Location = new Point(420, 278);
            label3.Name = "label3";
            label3.Size = new Size(82, 23);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // iconButtonVisibilityPassword
            // 
            iconButtonVisibilityPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            iconButtonVisibilityPassword.IconColor = Color.Black;
            iconButtonVisibilityPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonVisibilityPassword.IconSize = 24;
            iconButtonVisibilityPassword.Location = new Point(678, 310);
            iconButtonVisibilityPassword.Name = "iconButtonVisibilityPassword";
            iconButtonVisibilityPassword.Size = new Size(30, 30);
            iconButtonVisibilityPassword.TabIndex = 9;
            iconButtonVisibilityPassword.Text = "e2";
            iconButtonVisibilityPassword.UseVisualStyleBackColor = true;
            iconButtonVisibilityPassword.Click += iconButtonVisibilityPassword_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(431, 459);
            label4.Name = "label4";
            label4.Size = new Size(264, 20);
            label4.TabIndex = 10;
            label4.Text = "Codework Solution. All rights reserved.";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(815, 507);
            Controls.Add(label4);
            Controls.Add(iconButtonVisibilityPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosed += FormLogin_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBoxEmail;
        private Button buttonLogin;
        private TextBox textBoxPassword;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButtonVisibilityPassword;
        private Label label4;
    }
}
