namespace Gemilang.Views.Pages.MataPelajaran
{
    partial class PageTambahEditMataPelajaran
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
            textBoxNamaMataPelajaran = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelJudul.Location = new Point(25, 23);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(373, 50);
            labelJudul.TabIndex = 22;
            labelJudul.Text = "Mata Pelajaran Baru";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(255, 0, 92);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(255, 0, 92);
            buttonCancel.Location = new Point(36, 210);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(135, 45);
            buttonCancel.TabIndex = 26;
            buttonCancel.Text = "Batal";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.FromArgb(255, 0, 92);
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(197, 210);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(135, 45);
            buttonTambah.TabIndex = 25;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // textBoxNamaMataPelajaran
            // 
            textBoxNamaMataPelajaran.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNamaMataPelajaran.Font = new Font("Segoe UI", 10.5F);
            textBoxNamaMataPelajaran.Location = new Point(36, 143);
            textBoxNamaMataPelajaran.MaximumSize = new Size(700, 0);
            textBoxNamaMataPelajaran.MaxLength = 100;
            textBoxNamaMataPelajaran.Name = "textBoxNamaMataPelajaran";
            textBoxNamaMataPelajaran.PlaceholderText = "Nama Mata Pelajaran";
            textBoxNamaMataPelajaran.Size = new Size(270, 31);
            textBoxNamaMataPelajaran.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(36, 101);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 23;
            label1.Text = "Nama";
            // 
            // PageTambahEditMataPelajaran
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labelJudul);
            Controls.Add(buttonCancel);
            Controls.Add(buttonTambah);
            Controls.Add(textBoxNamaMataPelajaran);
            Controls.Add(label1);
            Name = "PageTambahEditMataPelajaran";
            Size = new Size(526, 291);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelJudul;
        private Button buttonCancel;
        private Button buttonTambah;
        private TextBox textBoxNamaMataPelajaran;
        private Label label1;
    }
}
