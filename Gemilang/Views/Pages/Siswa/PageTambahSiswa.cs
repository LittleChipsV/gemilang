using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MSiswa = Gemilang.Models.Siswa;
using MKelas = Gemilang.Models.Kelas;
using FontAwesome.Sharp;

namespace Gemilang.Views.Pages.Siswa
{
    public partial class PageTambahSiswa : UserControl
    {
        private readonly NavigasiService navigasiService;
        private readonly GemilangDbContext gemilangDbContext;
        private readonly MSiswa siswa;

        public PageTambahSiswa(NavigasiService navigasiService, GemilangDbContext context, MSiswa siswa = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            gemilangDbContext = context;
            this.siswa = siswa;

            Task.Run(LoadDataKelas);

            if (siswa != null)
                SetUpPageEditForm();
        }

        private async Task LoadDataKelas()
        {
            var kelas = await gemilangDbContext.Kelas.ToListAsync();
            kelas.Insert(0, new MKelas { Nama = "Pilih kelas" });

            comboBoxKelas.DataSource = kelas;
            comboBoxKelas.DisplayMember = "Nama";
            comboBoxKelas.ValueMember = "Id";

            if (siswa != null)
                comboBoxKelas.SelectedValue = siswa.IdKelas;
        }

        private void SetUpPageEditForm()
        {
            labelJudul.Text = "Edit Siswa";
            buttonTambah.Text = "Edit";

            textBoxUsername.Text = siswa.Username;
            textBoxEmail.Text = siswa.Email;
        }

        private void buttonCancel_Click(object sender, EventArgs e) => BalikKeHalamanIndex();

        private void iconButtonTogglePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            iconButtonTogglePassword.IconChar = textBoxPassword.UseSystemPasswordChar ? IconChar.Eye : IconChar.EyeSlash;
        }

        private async void buttonTambah_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            int idKelasYangDipilih = comboBoxKelas.SelectedValue == null ? 0 : (int)comboBoxKelas.SelectedValue;

            if (username.Length < 4)
                ShowPesanWarning("Username minimal harus berjumlah 4 karakter");
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                ShowPesanWarning("Email yang dimasukkan tidak valid");
            else if (password.Length < 5 && siswa == null)
                ShowPesanWarning("Password minimal harus berjumlah 5 karakter");
            else if (idKelasYangDipilih == 0)
                ShowPesanWarning("Pilih kelas terlebih dahulu");
            else if (await EmailSudahTerpakai(email))
                ShowPesanWarning("Email sudah dipakai akun lain");
            else
            {
                if (siswa == null)
                {
                    await Tambah(username, email, password, idKelasYangDipilih);
                }
                else
                {
                    await Update(siswa, username, email, password, idKelasYangDipilih);
                }

                ShowPesanInfo($"Berhasil {(siswa == null ? "menambah" : "mengupdate")} siswa!");
                BalikKeHalamanIndex();
            }
        }

        private async Task<bool> EmailSudahTerpakai(string email)
        {
            if (siswa == null)
            {
                return await gemilangDbContext.Siswa.AnyAsync(s => s.Email == email);
            }
            else
            {
                return await gemilangDbContext.Siswa.AnyAsync(s => s.Email == email && s.Id != siswa.Id);
            }
        }

        private async Task Tambah(string username, string email, string password, int idKelas)
        {
            gemilangDbContext.Siswa.Add(new MSiswa
            {
                Username = username,
                Email = email,
                Password = Enkripsi.BuatSHA256Hash(password),
                IdKelas = idKelas,
                Role = Role.siswa
            });

            await gemilangDbContext.SaveChangesAsync();
        }

        private async Task Update(MSiswa siswa, string username, string email, string password, int idKelas)
        {
            siswa.Username = username;
            siswa.Email = email;
            siswa.IdKelas = idKelas;
            if (!string.IsNullOrEmpty(password))
            {
                siswa.Password = Enkripsi.BuatSHA256Hash(password);
            }

            await gemilangDbContext.SaveChangesAsync();
        }

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexSiswa(navigasiService));
    }
}
