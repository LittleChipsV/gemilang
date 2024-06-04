namespace Gemilang.Views.Pages.Nilai
{
    partial class PagePilihSpesifikasiNilai
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
            buttonPilih = new Button();
            label1 = new Label();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonPilih
            // 
            buttonPilih.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonPilih.BackColor = Color.Black;
            buttonPilih.FlatStyle = FlatStyle.Flat;
            buttonPilih.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonPilih.ForeColor = Color.White;
            buttonPilih.Location = new Point(17, 452);
            buttonPilih.Margin = new Padding(2, 4, 2, 4);
            buttonPilih.Name = "buttonPilih";
            buttonPilih.Size = new Size(125, 35);
            buttonPilih.TabIndex = 17;
            buttonPilih.Text = "Pilih";
            buttonPilih.UseVisualStyleBackColor = false;
            buttonPilih.Click += ButtonPilih_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(389, 41);
            label1.TabIndex = 16;
            label1.Text = "Pilih Mata Pelajaran - Kelas";
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
            dataGridView.Location = new Point(17, 82);
            dataGridView.Margin = new Padding(2, 4, 2, 4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(928, 351);
            dataGridView.TabIndex = 15;
            // 
            // PagePilihSpesifikasiNilai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(buttonPilih);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Name = "PagePilihSpesifikasiNilai";
            Size = new Size(963, 506);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonPilih;
        private Label label1;
        private DataGridView dataGridView;
    }
}
