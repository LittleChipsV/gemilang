namespace Gemilang.Views.Pages.Topik
{
    partial class PageTambahEditTopik
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
            textBoxNamaTopik = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelJudul.Location = new Point(18, 21);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(210, 50);
            labelJudul.TabIndex = 11;
            labelJudul.Text = "Topik Baru";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(255, 0, 92);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(255, 0, 92);
            buttonCancel.Location = new Point(32, 210);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(135, 45);
            buttonCancel.TabIndex = 21;
            buttonCancel.Text = "Batal";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.FromArgb(255, 0, 92);
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(191, 210);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(135, 45);
            buttonTambah.TabIndex = 20;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // textBoxNamaTopik
            // 
            textBoxNamaTopik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNamaTopik.Font = new Font("Segoe UI", 10.5F);
            textBoxNamaTopik.Location = new Point(29, 141);
            textBoxNamaTopik.MaximumSize = new Size(700, 0);
            textBoxNamaTopik.MaxLength = 100;
            textBoxNamaTopik.Name = "textBoxNamaTopik";
            textBoxNamaTopik.PlaceholderText = "Nama topik";
            textBoxNamaTopik.Size = new Size(270, 31);
            textBoxNamaTopik.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(29, 99);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 12;
            label1.Text = "Nama Topik";
            // 
            // PageTambahEditTopik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labelJudul);
            Controls.Add(buttonCancel);
            Controls.Add(buttonTambah);
            Controls.Add(textBoxNamaTopik);
            Controls.Add(label1);
            Name = "PageTambahEditTopik";
            Size = new Size(526, 282);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelJudul;
        private Button buttonCancel;
        private Button buttonTambah;
        private TextBox textBoxNamaTopik;
        private Label label1;
    }
}
