namespace Gemilang.UserControls
{
    partial class CardStatistik
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
            pictureBox1 = new PictureBox();
            labelJudul = new Label();
            labelJumlah = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.card_statistik_icon;
            pictureBox1.Location = new Point(247, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(59, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 12F);
            labelJudul.ForeColor = Color.FromArgb(32, 34, 36);
            labelJudul.Location = new Point(15, 16);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(100, 28);
            labelJudul.TabIndex = 1;
            labelJudul.Text = "labelJudul";
            // 
            // labelJumlah
            // 
            labelJumlah.AutoSize = true;
            labelJumlah.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJumlah.Location = new Point(15, 56);
            labelJumlah.Name = "labelJumlah";
            labelJumlah.Size = new Size(175, 38);
            labelJumlah.TabIndex = 2;
            labelJumlah.Text = "labelJumlah";
            // 
            // CardStatistik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelJumlah);
            Controls.Add(labelJudul);
            Controls.Add(pictureBox1);
            Name = "CardStatistik";
            Size = new Size(320, 200);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelJudul;
        private Label labelJumlah;
    }
}
