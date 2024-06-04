namespace Gemilang.Views.Pages.Siswa
{
    partial class PageIndexSiswa
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
            textBoxSearch = new TextBox();
            comboBoxFilterKelas = new ComboBox();
            buttonTambah = new Button();
            label1 = new Label();
            dataGridView = new DataGridView();
            buttonHapus = new Button();
            buttonEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(609, 27);
            textBoxSearch.Margin = new Padding(2, 4, 2, 4);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search";
            textBoxSearch.Size = new Size(183, 30);
            textBoxSearch.TabIndex = 14;
            // 
            // comboBoxFilterKelas
            // 
            comboBoxFilterKelas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFilterKelas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterKelas.FormattingEnabled = true;
            comboBoxFilterKelas.Location = new Point(415, 28);
            comboBoxFilterKelas.Margin = new Padding(2, 4, 2, 4);
            comboBoxFilterKelas.Name = "comboBoxFilterKelas";
            comboBoxFilterKelas.Size = new Size(171, 28);
            comboBoxFilterKelas.TabIndex = 13;
            // 
            // buttonTambah
            // 
            buttonTambah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTambah.BackColor = Color.Black;
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(820, 24);
            buttonTambah.Margin = new Padding(2, 4, 2, 4);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(125, 35);
            buttonTambah.TabIndex = 12;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(189, 41);
            label1.TabIndex = 11;
            label1.Text = "Daftar Siswa";
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
            dataGridView.Location = new Point(17, 86);
            dataGridView.Margin = new Padding(2, 4, 2, 4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(928, 352);
            dataGridView.TabIndex = 10;
            // 
            // buttonHapus
            // 
            buttonHapus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonHapus.BackColor = Color.Black;
            buttonHapus.FlatStyle = FlatStyle.Flat;
            buttonHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonHapus.ForeColor = Color.White;
            buttonHapus.Location = new Point(164, 457);
            buttonHapus.Margin = new Padding(2, 4, 2, 4);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(125, 35);
            buttonHapus.TabIndex = 23;
            buttonHapus.Text = "Hapus";
            buttonHapus.UseVisualStyleBackColor = false;
            buttonHapus.Click += ButtonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEdit.BackColor = Color.Black;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(17, 457);
            buttonEdit.Margin = new Padding(2, 4, 2, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(125, 35);
            buttonEdit.TabIndex = 22;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += ButtonEdit_Click;
            // 
            // PageIndexSiswa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(buttonHapus);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxSearch);
            Controls.Add(comboBoxFilterKelas);
            Controls.Add(buttonTambah);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Margin = new Padding(2, 4, 2, 4);
            Name = "PageIndexSiswa";
            Size = new Size(963, 506);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSearch;
        private ComboBox comboBoxFilterKelas;
        private Button buttonTambah;
        private Label label1;
        private DataGridView dataGridView;
        private Button buttonHapus;
        private Button buttonEdit;
    }
}
