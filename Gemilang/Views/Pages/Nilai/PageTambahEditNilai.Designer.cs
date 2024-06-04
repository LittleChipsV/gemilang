namespace Gemilang.Views.Pages.Nilai
{
    partial class PageTambahEditNilai
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
            label1 = new Label();
            comboBoxSiswa = new ComboBox();
            comboBoxTopik = new ComboBox();
            label3 = new Label();
            numericUpDownNilai = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNilai).BeginInit();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelJudul.Location = new Point(17, 24);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(195, 50);
            labelJudul.TabIndex = 27;
            labelJudul.Text = "Nilai Baru";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(255, 0, 92);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(255, 0, 92);
            buttonCancel.Location = new Point(31, 399);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(135, 45);
            buttonCancel.TabIndex = 31;
            buttonCancel.Text = "Batal";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.FromArgb(255, 0, 92);
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(196, 399);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(135, 45);
            buttonTambah.TabIndex = 30;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(25, 102);
            label1.Name = "label1";
            label1.Size = new Size(62, 28);
            label1.TabIndex = 28;
            label1.Text = "Siswa";
            // 
            // comboBoxSiswa
            // 
            comboBoxSiswa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSiswa.FormattingEnabled = true;
            comboBoxSiswa.Location = new Point(28, 142);
            comboBoxSiswa.Name = "comboBoxSiswa";
            comboBoxSiswa.Size = new Size(260, 28);
            comboBoxSiswa.TabIndex = 32;
            // 
            // comboBoxTopik
            // 
            comboBoxTopik.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTopik.FormattingEnabled = true;
            comboBoxTopik.Location = new Point(31, 228);
            comboBoxTopik.Name = "comboBoxTopik";
            comboBoxTopik.Size = new Size(257, 28);
            comboBoxTopik.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(25, 191);
            label3.Name = "label3";
            label3.Size = new Size(61, 28);
            label3.TabIndex = 35;
            label3.Text = "Topik";
            // 
            // numericUpDownNilai
            // 
            numericUpDownNilai.Location = new Point(31, 320);
            numericUpDownNilai.Name = "numericUpDownNilai";
            numericUpDownNilai.Size = new Size(257, 27);
            numericUpDownNilai.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(25, 283);
            label4.Name = "label4";
            label4.Size = new Size(52, 28);
            label4.TabIndex = 38;
            label4.Text = "Nilai";
            // 
            // PageTambahEditNilai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(comboBoxSiswa);
            Controls.Add(label4);
            Controls.Add(numericUpDownNilai);
            Controls.Add(comboBoxTopik);
            Controls.Add(label3);
            Controls.Add(labelJudul);
            Controls.Add(buttonCancel);
            Controls.Add(buttonTambah);
            Name = "PageTambahEditNilai";
            Size = new Size(596, 475);
            ((System.ComponentModel.ISupportInitialize)numericUpDownNilai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelJudul;
        private Button buttonCancel;
        private Button buttonTambah;
        private Label label1;
        private ComboBox comboBoxSiswa;
        private ComboBox comboBoxTopik;
        private Label label3;
        private NumericUpDown numericUpDownNilai;
        private Label label4;
    }
}
