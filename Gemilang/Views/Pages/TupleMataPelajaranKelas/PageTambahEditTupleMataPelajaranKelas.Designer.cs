namespace Gemilang.Views.Pages.TupleMataPelajaranKelas
{
    partial class PageTambahEditTupleMataPelajaranKelas
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
            comboBoxMataPelajaran = new ComboBox();
            labelJudul = new Label();
            buttonCancel = new Button();
            buttonTambah = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBoxKelas = new ComboBox();
            SuspendLayout();
            // 
            // comboBoxMataPelajaran
            // 
            comboBoxMataPelajaran.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMataPelajaran.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMataPelajaran.Font = new Font("Segoe UI", 10.5F);
            comboBoxMataPelajaran.FormattingEnabled = true;
            comboBoxMataPelajaran.Location = new Point(33, 151);
            comboBoxMataPelajaran.MaximumSize = new Size(700, 0);
            comboBoxMataPelajaran.Name = "comboBoxMataPelajaran";
            comboBoxMataPelajaran.Size = new Size(270, 31);
            comboBoxMataPelajaran.TabIndex = 39;
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelJudul.Location = new Point(22, 31);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(453, 50);
            labelJudul.TabIndex = 35;
            labelJudul.Text = "Tuple Mapel - Kelas Baru";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(255, 0, 92);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(255, 0, 92);
            buttonCancel.Location = new Point(31, 338);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(135, 45);
            buttonCancel.TabIndex = 38;
            buttonCancel.Text = "Batal";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.FromArgb(255, 0, 92);
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(192, 338);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(135, 45);
            buttonTambah.TabIndex = 37;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(33, 109);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 36;
            label1.Text = "Mata Pelajaran";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(33, 208);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 40;
            label2.Text = "Kelas";
            // 
            // comboBoxKelas
            // 
            comboBoxKelas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxKelas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKelas.Font = new Font("Segoe UI", 10.5F);
            comboBoxKelas.FormattingEnabled = true;
            comboBoxKelas.Location = new Point(33, 250);
            comboBoxKelas.MaximumSize = new Size(700, 0);
            comboBoxKelas.Name = "comboBoxKelas";
            comboBoxKelas.Size = new Size(270, 31);
            comboBoxKelas.TabIndex = 41;
            // 
            // PageTambahEditTupleMataPelajaranKelas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(comboBoxKelas);
            Controls.Add(label2);
            Controls.Add(comboBoxMataPelajaran);
            Controls.Add(labelJudul);
            Controls.Add(buttonCancel);
            Controls.Add(buttonTambah);
            Controls.Add(label1);
            Name = "PageTambahEditTupleMataPelajaranKelas";
            Size = new Size(526, 414);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxMataPelajaran;
        private Label labelJudul;
        private Button buttonCancel;
        private Button buttonTambah;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxKelas;
    }
}
