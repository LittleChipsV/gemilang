namespace Gemilang.Views.Forms
{
    partial class FormHome
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanelSidebar = new FlowLayoutPanel();
            panelLogoSidebar = new Panel();
            label1 = new Label();
            pictureBoxLogo = new PictureBox();
            panel1 = new Panel();
            labelRole = new Label();
            labelUsername = new Label();
            iconButtonProfil = new FontAwesome.Sharp.IconButton();
            labelHeading = new Label();
            panelUtama = new Panel();
            panelProfil = new Panel();
            label2 = new Label();
            iconButtonLogout = new FontAwesome.Sharp.IconButton();
            flowLayoutPanelSidebar.SuspendLayout();
            panelLogoSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panel1.SuspendLayout();
            panelProfil.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelSidebar
            // 
            flowLayoutPanelSidebar.BackColor = Color.White;
            flowLayoutPanelSidebar.Controls.Add(panelLogoSidebar);
            flowLayoutPanelSidebar.Dock = DockStyle.Left;
            flowLayoutPanelSidebar.Location = new Point(0, 0);
            flowLayoutPanelSidebar.Name = "flowLayoutPanelSidebar";
            flowLayoutPanelSidebar.Size = new Size(247, 489);
            flowLayoutPanelSidebar.TabIndex = 0;
            // 
            // panelLogoSidebar
            // 
            panelLogoSidebar.Controls.Add(label1);
            panelLogoSidebar.Controls.Add(pictureBoxLogo);
            panelLogoSidebar.Location = new Point(20, 20);
            panelLogoSidebar.Margin = new Padding(20);
            panelLogoSidebar.Name = "panelLogoSidebar";
            panelLogoSidebar.Size = new Size(204, 59);
            panelLogoSidebar.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 0, 92);
            label1.Location = new Point(49, 9);
            label1.Name = "label1";
            label1.Size = new Size(157, 48);
            label1.TabIndex = 1;
            label1.Text = "Gemilang";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.logo;
            pictureBoxLogo.Location = new Point(0, 3);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(54, 50);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(labelRole);
            panel1.Controls.Add(labelUsername);
            panel1.Controls.Add(iconButtonProfil);
            panel1.Controls.Add(labelHeading);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(247, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(730, 89);
            panel1.TabIndex = 4;
            // 
            // labelRole
            // 
            labelRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelRole.AutoEllipsis = true;
            labelRole.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRole.Location = new Point(579, 41);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(139, 24);
            labelRole.TabIndex = 6;
            labelRole.Text = "Role";
            labelRole.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelUsername
            // 
            labelUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelUsername.AutoEllipsis = true;
            labelUsername.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(578, 15);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(139, 30);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username";
            labelUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iconButtonProfil
            // 
            iconButtonProfil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonProfil.FlatAppearance.BorderSize = 0;
            iconButtonProfil.FlatStyle = FlatStyle.Flat;
            iconButtonProfil.IconChar = FontAwesome.Sharp.IconChar.CircleUser;
            iconButtonProfil.IconColor = Color.Black;
            iconButtonProfil.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButtonProfil.IconSize = 56;
            iconButtonProfil.Location = new Point(528, 24);
            iconButtonProfil.Name = "iconButtonProfil";
            iconButtonProfil.Size = new Size(44, 46);
            iconButtonProfil.TabIndex = 5;
            iconButtonProfil.UseVisualStyleBackColor = true;
            iconButtonProfil.Click += iconButtonProfil_Click;
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeading.Location = new Point(23, 27);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(159, 38);
            labelHeading.TabIndex = 4;
            labelHeading.Text = "Dashboard";
            // 
            // panelUtama
            // 
            panelUtama.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUtama.BackColor = Color.White;
            panelUtama.Location = new Point(270, 124);
            panelUtama.Margin = new Padding(20);
            panelUtama.Name = "panelUtama";
            panelUtama.Size = new Size(678, 336);
            panelUtama.TabIndex = 5;
            // 
            // panelProfil
            // 
            panelProfil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelProfil.BackColor = Color.White;
            panelProfil.BorderStyle = BorderStyle.FixedSingle;
            panelProfil.Controls.Add(label2);
            panelProfil.Controls.Add(iconButtonLogout);
            panelProfil.Location = new Point(697, 72);
            panelProfil.Name = "panelProfil";
            panelProfil.Size = new Size(200, 109);
            panelProfil.TabIndex = 6;
            panelProfil.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 12);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 1;
            label2.Text = "Menu Profil";
            // 
            // iconButtonLogout
            // 
            iconButtonLogout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconButtonLogout.FlatStyle = FlatStyle.Flat;
            iconButtonLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButtonLogout.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            iconButtonLogout.IconColor = Color.Black;
            iconButtonLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonLogout.IconSize = 26;
            iconButtonLogout.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonLogout.Location = new Point(20, 54);
            iconButtonLogout.Name = "iconButtonLogout";
            iconButtonLogout.Size = new Size(163, 38);
            iconButtonLogout.TabIndex = 0;
            iconButtonLogout.Text = "Logout";
            iconButtonLogout.UseVisualStyleBackColor = true;
            iconButtonLogout.Click += iconButtonLogout_Click;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 251, 252);
            ClientSize = new Size(977, 489);
            Controls.Add(panelProfil);
            Controls.Add(panelUtama);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanelSidebar);
            Name = "FormHome";
            Text = "FormHome";
            FormClosed += FormHome_FormClosed;
            flowLayoutPanelSidebar.ResumeLayout(false);
            panelLogoSidebar.ResumeLayout(false);
            panelLogoSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelProfil.ResumeLayout(false);
            panelProfil.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelSidebar;
        private Panel panelLogoSidebar;
        private Label label1;
        private PictureBox pictureBoxLogo;
        private Panel panel1;
        private Panel panelUtama;
        private Label labelHeading;
        private FontAwesome.Sharp.IconButton iconButtonProfil;
        private Panel panelProfil;
        private Label labelUsername;
        private Label labelRole;
        private FontAwesome.Sharp.IconButton iconButtonLogout;
        private Label label2;
    }
}