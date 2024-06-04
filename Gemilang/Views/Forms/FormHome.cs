using FontAwesome.Sharp;
using Gemilang.CustomControls;
using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages;
using Gemilang.Views.Pages.Guru;
using Gemilang.Views.Pages.Kelas;
using Gemilang.Views.Pages.MataPelajaran;
using Gemilang.Views.Pages.Nilai;
using Gemilang.Views.Pages.Siswa;
using Gemilang.Views.Pages.Topik;
using Gemilang.Views.Pages.TupleMataPelajaranKelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gemilang.Views.Forms
{
    public partial class FormHome : Form
    {
        private NavigasiService navigasiService;
        private readonly User userSekarang;

        public FormHome(User user)
        {
            InitializeComponent();

            userSekarang = user;
            labelUsername.Text = user.Username;
            labelRole.Text = user.Role.ToString();

            navigasiService = new NavigasiService(panelUtama);

            SetButtonSidebar();

            panelUtama.Controls.Add(new PageDashboard());
        }

        private void SetButtonSidebar()
        {
            IconButton buttonDashboard = BuatButtonSidebar("Dashboard", IconChar.GaugeHigh, () => navigasiService.Navigasi(new Pages.PageDashboard()));

            flowLayoutPanelSidebar.Controls.Add(buttonDashboard);

            switch (userSekarang.Role)
            {
                case Role.admin:
                    flowLayoutPanelSidebar.Controls.AddRange(
                    [
                        BuatButtonSidebar("Siswa", IconChar.Users, () => navigasiService.Navigasi(new PageIndexSiswa(navigasiService))),
                        BuatButtonSidebar("Guru", IconChar.Users, () => navigasiService.Navigasi(new PageIndexGuru(navigasiService))),
                        BuatButtonSidebar("Kelas", IconChar.Chalkboard, () => navigasiService.Navigasi(new PageIndexKelas(navigasiService))),
                        BuatButtonSidebar("Mata Pelajaran", IconChar.List, () => navigasiService.Navigasi(new PageIndexMataPelajaran(navigasiService))),
                        BuatButtonSidebar("Mapel-Kelas", IconChar.List, () => navigasiService.Navigasi(new PageIndexTupleMataPelajaranKelas(navigasiService))),
                    ]);
                    break;
                case Role.guru:
                    flowLayoutPanelSidebar.Controls.AddRange(
                    [
                        BuatButtonSidebar("Topik",IconChar.List, () => navigasiService.Navigasi(new PagePilihMataPelajaranKelasYangDiajar(navigasiService, (Guru)userSekarang))),
                        BuatButtonSidebar("Nilai", IconChar.List, () => navigasiService.Navigasi(new PagePilihSpesifikasiNilai(navigasiService, userSekarang)))
                    ]);
                    break;
                case Role.siswa:
                    flowLayoutPanelSidebar.Controls.AddRange(
                    [
                        BuatButtonSidebar("Nilai", IconChar.List, () => navigasiService.Navigasi(new PagePilihSpesifikasiNilai(navigasiService, userSekarang)))
                    ]);
                    break;
            }

            AturActiveStateButtonSidebar(buttonDashboard);
        }

        private IconButton BuatButtonSidebar(string text, IconChar icon, Action onclick)
        {
            IconButton button = new IconButton()
            {
                BackColor = Color.FromArgb(255, 0, 92),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(panelLogoSidebar.Width, 50),
                Margin = new Padding(20, 20, 20, 0),
                Text = text,
                IconChar = icon,
                IconSize = 28,
                IconColor = Color.White,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            button.Click += delegate
            {
                AturActiveStateButtonSidebar(button);
                onclick.Invoke();
            };
            return button;
        }

        private void AturActiveStateButtonSidebar(IconButton iconButtonAktif)
        {
            foreach (Control kontrol in flowLayoutPanelSidebar.Controls)
            {
                if (kontrol is IconButton iconButton)
                {
                    iconButton.BackColor = Color.Transparent;
                    iconButton.ForeColor = iconButton.IconColor = Color.FromArgb(255, 0, 92);
                }
            }

            iconButtonAktif.BackColor = Color.FromArgb(255, 0, 92);
            iconButtonAktif.ForeColor = iconButtonAktif.IconColor = Color.White;
            labelHeading.Text = iconButtonAktif.Text;
        }

        private void iconButtonProfil_Enter(object sender, EventArgs e) => panelProfil.Visible = true;

        private void iconButtonProfil_Leave(object sender, EventArgs e) => panelProfil.Visible = false;

        private void iconButtonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah kamu yakin ingin logout", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Hide();
                new FormLogin().Show();
            }
        }

        private void iconButtonProfil_Click(object sender, EventArgs e) => panelProfil.Visible = !panelProfil.Visible;

        private void FormHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
