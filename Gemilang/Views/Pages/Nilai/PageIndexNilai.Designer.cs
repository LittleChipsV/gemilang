namespace Gemilang.Views.Pages.Nilai
{
    partial class PageIndexNilai
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
            buttonHapus = new Button();
            buttonEdit = new Button();
            textBoxSearch = new TextBox();
            buttonTambah = new Button();
            label1 = new Label();
            dataGridView = new DataGridView();
            comboBoxFilterTopik = new ComboBox();
            buttonPrint = new Button();
            buttonStatistik = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonHapus
            // 
            buttonHapus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonHapus.BackColor = Color.Black;
            buttonHapus.FlatStyle = FlatStyle.Flat;
            buttonHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonHapus.ForeColor = Color.White;
            buttonHapus.Location = new Point(164, 452);
            buttonHapus.Margin = new Padding(2, 4, 2, 4);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(125, 35);
            buttonHapus.TabIndex = 30;
            buttonHapus.Text = "Hapus";
            buttonHapus.UseVisualStyleBackColor = false;
            buttonHapus.Click += ButtonHapus_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEdit.BackColor = Color.Black;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(17, 452);
            buttonEdit.Margin = new Padding(2, 4, 2, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(125, 35);
            buttonEdit.TabIndex = 29;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += ButtonEdit_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(762, 28);
            textBoxSearch.Margin = new Padding(2, 4, 2, 4);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search";
            textBoxSearch.Size = new Size(183, 30);
            textBoxSearch.TabIndex = 28;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.Black;
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(207, 25);
            buttonTambah.Margin = new Padding(2, 4, 2, 4);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(125, 35);
            buttonTambah.TabIndex = 26;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(176, 41);
            label1.TabIndex = 25;
            label1.Text = "Daftar Nilai";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.GridColor = Color.White;
            dataGridView.Location = new Point(17, 81);
            dataGridView.Margin = new Padding(2, 4, 2, 4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(928, 352);
            dataGridView.TabIndex = 24;
            // 
            // comboBoxFilterTopik
            // 
            comboBoxFilterTopik.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFilterTopik.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterTopik.FormattingEnabled = true;
            comboBoxFilterTopik.Location = new Point(547, 29);
            comboBoxFilterTopik.Name = "comboBoxFilterTopik";
            comboBoxFilterTopik.Size = new Size(191, 28);
            comboBoxFilterTopik.TabIndex = 31;
            // 
            // buttonPrint
            // 
            buttonPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonPrint.BackColor = Color.Black;
            buttonPrint.FlatStyle = FlatStyle.Flat;
            buttonPrint.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonPrint.ForeColor = Color.White;
            buttonPrint.Location = new Point(820, 452);
            buttonPrint.Margin = new Padding(2, 4, 2, 4);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(125, 35);
            buttonPrint.TabIndex = 32;
            buttonPrint.Text = "Print";
            buttonPrint.UseVisualStyleBackColor = false;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // buttonStatistik
            // 
            buttonStatistik.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonStatistik.BackColor = Color.Black;
            buttonStatistik.FlatStyle = FlatStyle.Flat;
            buttonStatistik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonStatistik.ForeColor = Color.White;
            buttonStatistik.Location = new Point(661, 452);
            buttonStatistik.Margin = new Padding(2, 4, 2, 4);
            buttonStatistik.Name = "buttonStatistik";
            buttonStatistik.Size = new Size(143, 35);
            buttonStatistik.TabIndex = 33;
            buttonStatistik.Text = "Lihat Statistik";
            buttonStatistik.UseVisualStyleBackColor = false;
            buttonStatistik.Click += buttonStatistik_Click;
            // 
            // PageIndexNilai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(buttonStatistik);
            Controls.Add(buttonPrint);
            Controls.Add(comboBoxFilterTopik);
            Controls.Add(buttonHapus);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonTambah);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Name = "PageIndexNilai";
            Size = new Size(963, 506);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonHapus;
        private Button buttonEdit;
        private TextBox textBoxSearch;
        private Button buttonTambah;
        private Label label1;
        private DataGridView dataGridView;
        private ComboBox comboBoxFilterTopik;
        private Button buttonPrint;
        private Button buttonStatistik;
    }
}
