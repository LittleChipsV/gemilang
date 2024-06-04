namespace Gemilang.Views.Pages.Siswa
{
    partial class PageTambahSiswa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelJudul = new Label();
            buttonCancel = new Button();
            buttonTambah = new Button();
            label4 = new Label();
            comboBoxKelas = new ComboBox();
            textBoxPassword = new TextBox();
            label3 = new Label();
            textBoxEmail = new TextBox();
            label2 = new Label();
            textBoxUsername = new TextBox();
            label1 = new Label();
            iconButtonTogglePassword = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelJudul.Location = new Point(9, 20);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(211, 50);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Siswa Baru";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(255, 0, 92);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(255, 0, 92);
            buttonCancel.Location = new Point(19, 492);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(135, 45);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Batal";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.FromArgb(255, 0, 92);
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(178, 492);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(135, 45);
            buttonTambah.TabIndex = 9;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(20, 381);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 7;
            label4.Text = "Kelas";
            // 
            // comboBoxKelas
            // 
            comboBoxKelas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxKelas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKelas.Font = new Font("Segoe UI", 10.5F);
            comboBoxKelas.FormattingEnabled = true;
            comboBoxKelas.Location = new Point(20, 421);
            comboBoxKelas.MaximumSize = new Size(700, 0);
            comboBoxKelas.Name = "comboBoxKelas";
            comboBoxKelas.Size = new Size(270, 31);
            comboBoxKelas.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Font = new Font("Segoe UI", 10.5F);
            textBoxPassword.Location = new Point(3, 3);
            textBoxPassword.MaxLength = 255;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Password baru";
            textBoxPassword.Size = new Size(227, 31);
            textBoxPassword.TabIndex = 0;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(19, 287);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEmail.Font = new Font("Segoe UI", 10.5F);
            textBoxEmail.Location = new Point(20, 232);
            textBoxEmail.MaximumSize = new Size(700, 0);
            textBoxEmail.MaxLength = 255;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.Size = new Size(270, 31);
            textBoxEmail.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(20, 193);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsername.Font = new Font("Segoe UI", 10.5F);
            textBoxUsername.Location = new Point(20, 140);
            textBoxUsername.MaximumSize = new Size(700, 0);
            textBoxUsername.MaxLength = 100;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Username";
            textBoxUsername.Size = new Size(270, 31);
            textBoxUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(20, 98);
            label1.Name = "label1";
            label1.Size = new Size(104, 28);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // iconButtonTogglePassword
            // 
            iconButtonTogglePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonTogglePassword.FlatAppearance.BorderSize = 0;
            iconButtonTogglePassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            iconButtonTogglePassword.IconColor = Color.Black;
            iconButtonTogglePassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonTogglePassword.IconSize = 24;
            iconButtonTogglePassword.Location = new Point(236, 3);
            iconButtonTogglePassword.Name = "iconButtonTogglePassword";
            iconButtonTogglePassword.Size = new Size(31, 31);
            iconButtonTogglePassword.TabIndex = 1;
            iconButtonTogglePassword.UseVisualStyleBackColor = true;
            iconButtonTogglePassword.Click += iconButtonTogglePassword_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(iconButtonTogglePassword);
            panel1.Location = new Point(20, 321);
            panel1.MaximumSize = new Size(700, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 39);
            panel1.TabIndex = 6;
            // 
            // PageTambahSiswa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(labelJudul);
            Controls.Add(buttonCancel);
            Controls.Add(buttonTambah);
            Controls.Add(label4);
            Controls.Add(comboBoxKelas);
            Controls.Add(label3);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(textBoxUsername);
            Controls.Add(label1);
            Name = "PageTambahSiswa";
            Size = new Size(526, 564);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelJudul;
        private Button buttonCancel;
        private Button buttonTambah;
        private Label label4;
        private ComboBox comboBoxKelas;
        private TextBox textBoxPassword;
        private Label label3;
        private TextBox textBoxEmail;
        private Label label2;
        private TextBox textBoxUsername;
        private Label label1;
        private FontAwesome.Sharp.IconButton iconButtonTogglePassword;
        private Panel panel1;
    }
}
