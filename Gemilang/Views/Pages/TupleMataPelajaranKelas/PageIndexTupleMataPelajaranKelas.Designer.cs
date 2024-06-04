namespace Gemilang.Views.Pages.TupleMataPelajaranKelas
{
    partial class PageIndexTupleMataPelajaranKelas
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
            buttonTambah = new Button();
            label1 = new Label();
            dataGridView = new DataGridView();
            buttonEdit = new Button();
            buttonHapus = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(619, 31);
            textBoxSearch.Margin = new Padding(2, 4, 2, 4);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search";
            textBoxSearch.Size = new Size(180, 30);
            textBoxSearch.TabIndex = 19;
            // 
            // buttonTambah
            // 
            buttonTambah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTambah.BackColor = Color.Black;
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.Location = new Point(821, 28);
            buttonTambah.Margin = new Padding(2, 4, 2, 4);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(125, 35);
            buttonTambah.TabIndex = 17;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(365, 41);
            label1.TabIndex = 16;
            label1.Text = "Daftar Tuple Mapel-Kelas";
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
            dataGridView.Location = new Point(19, 91);
            dataGridView.Margin = new Padding(2, 4, 2, 4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(928, 345);
            dataGridView.TabIndex = 15;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEdit.BackColor = Color.Black;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(19, 453);
            buttonEdit.Margin = new Padding(2, 4, 2, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(125, 35);
            buttonEdit.TabIndex = 20;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += ButtonEdit_Click;
            // 
            // buttonHapus
            // 
            buttonHapus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonHapus.BackColor = Color.Black;
            buttonHapus.FlatStyle = FlatStyle.Flat;
            buttonHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonHapus.ForeColor = Color.White;
            buttonHapus.Location = new Point(165, 453);
            buttonHapus.Margin = new Padding(2, 4, 2, 4);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(125, 35);
            buttonHapus.TabIndex = 21;
            buttonHapus.Text = "Hapus";
            buttonHapus.UseVisualStyleBackColor = false;
            buttonHapus.Click += ButtonHapus_Click;
            // 
            // PageIndexTupleMataPelajaranKelas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(buttonHapus);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonTambah);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Name = "PageIndexTupleMataPelajaranKelas";
            Size = new Size(963, 503);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSearch;
        private Button buttonTambah;
        private Label label1;
        private DataGridView dataGridView;
        private Button buttonEdit;
        private Button buttonHapus;
    }
}
