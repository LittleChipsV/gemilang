using FontAwesome.Sharp;
using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages.Siswa;
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
using MGuru = Gemilang.Models.Guru;
using MTupleMataPelajaranKelas = Gemilang.Models.TupleMataPelajaranKelas;
using MMataPelajaran = Gemilang.Models.MataPelajaran;
using MKelas = Gemilang.Models.Kelas;
using MDataPengajaran = Gemilang.Models.DataPengajaran;
using Gemilang.Views.Pages.TupleMataPelajaranKelas;

namespace Gemilang.Views.Pages.Guru
{
    public partial class PageTambahEditGuru : UserControl
    {
        private readonly NavigasiService navigasiService;
        private readonly GemilangDbContext gemilangDbContext;
        private readonly MGuru guru;
        private List<MTupleMataPelajaranKelas> listTupleMataPelajaranKelas;

        public PageTambahEditGuru(NavigasiService navigasiService, GemilangDbContext gemilangDbContext, MGuru guru = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            this.gemilangDbContext = gemilangDbContext;
            this.guru = guru;

            Task.Run(LoadDataTupleMataPelajaranKelas);

            if (guru != null)
                SetUpPageEditForm();
        }

        private void buttonCancel_Click(object sender, EventArgs e) => BalikKeHalamanIndex();

        private void iconButtonTogglePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            iconButtonTogglePassword.IconChar = textBoxPassword.UseSystemPasswordChar ? IconChar.Eye : IconChar.EyeSlash;
        }

        private async Task LoadDataTupleMataPelajaranKelas()
        {
            listTupleMataPelajaranKelas = await gemilangDbContext.TupleMataPelajaranKelas
               .Include(tmk => tmk.MataPelajaran)
               .Include(tmk => tmk.Kelas)
               .ToListAsync();

            if (checkedListBoxMataPelajaranKelas.InvokeRequired)
            {
                checkedListBoxMataPelajaranKelas.Invoke(new Action(() =>
                {
                    LoadTupleMataPelajaranKelasIntoListBox();
                }));
            }
            else
            {
                LoadTupleMataPelajaranKelasIntoListBox();
            }
        }

        private void LoadTupleMataPelajaranKelasIntoListBox()
        {
            checkedListBoxMataPelajaranKelas.Items.Clear();
            foreach (var tmk in listTupleMataPelajaranKelas)
            {
                checkedListBoxMataPelajaranKelas.Items.Add($"{tmk.MataPelajaran.Nama} | {tmk.Kelas.Nama}", false);
            }

            if (guru != null)
            {
                var guruTupleIds = guru.ListDataPengajaran.Select(dp => dp.IdTupleMataPelajaranKelas).ToList();

                for (int i = 0; i < listTupleMataPelajaranKelas.Count; i++)
                {
                    if (guruTupleIds.Contains(listTupleMataPelajaranKelas[i].Id))
                    {
                        checkedListBoxMataPelajaranKelas.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void SetUpPageEditForm()
        {
            labelJudul.Text = "Edit Guru";
            buttonTambah.Text = "Edit";

            textBoxUsername.Text = guru.Username;
            textBoxEmail.Text = guru.Email;
        }

        private async void buttonTambah_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (username.Length < 4)
                ShowPesanWarning("Username minimal harus berjumlah 4 karakter");
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                ShowPesanWarning("Email yang dimasukkan tidak valid");
            else if (password.Length < 5 && !string.IsNullOrEmpty(password))
                ShowPesanWarning("Password minimal harus berjumlah 5 karakter");
            else if (checkedListBoxMataPelajaranKelas.CheckedItems.Count == 0)
                ShowPesanWarning("Pilih minimal satu tuple mapel-kelas terlebih dahulu");
            else if (await EmailSudahTerpakai(email))
                ShowPesanWarning("Email sudah dipakai akun lain");
            else
            {
                var selectedTupleIds = checkedListBoxMataPelajaranKelas.CheckedIndices.Cast<int>().Select(i => listTupleMataPelajaranKelas[i].Id).ToList();

                if (guru == null)
                    await Tambah(username, email, password, selectedTupleIds);
                else
                    await Update(guru, username, email, password, selectedTupleIds);

                ShowPesanInfo($"Berhasil {(guru == null ? "menambah" : "mengupdate")} guru!");
                BalikKeHalamanIndex();
            }
        }

        private async Task<bool> EmailSudahTerpakai(string email)
        {
            if (guru == null)
            {
                return await gemilangDbContext.Guru.AnyAsync(s => s.Email == email);
            }
            else
            {
                return await gemilangDbContext.Guru.AnyAsync(s => s.Email == email && s.Id != guru.Id);
            }
        }

        private async Task Tambah(string username, string email, string password, List<int> selectedTupleIds)
        {
            var newGuru = new MGuru
            {
                Username = username,
                Email = email,
                Password = Enkripsi.BuatSHA256Hash(password),
                Role = Role.guru
            };

            gemilangDbContext.Guru.Add(newGuru);
            await gemilangDbContext.SaveChangesAsync();

            foreach (var idTupleMataPelajaranKelas in selectedTupleIds)
            {
                var newDataPengajaran = new MDataPengajaran
                {
                    IdGuru = newGuru.Id,
                    IdTupleMataPelajaranKelas = idTupleMataPelajaranKelas
                };

                gemilangDbContext.DataPengajaran.Add(newDataPengajaran);
            }

            await gemilangDbContext.SaveChangesAsync();
        }

        private async Task Update(MGuru guru, string username, string email, string password, List<int> selectedTupleIds)
        {
            guru.Username = username;
            guru.Email = email;

            if (password != guru.Password)
                guru.Password = Enkripsi.BuatSHA256Hash(password);

            var existingDataPengajaran = gemilangDbContext.DataPengajaran.Where(dp => dp.IdGuru == guru.Id).ToList();
            gemilangDbContext.DataPengajaran.RemoveRange(existingDataPengajaran);

            foreach (var idTupleMataPelajaranKelas in selectedTupleIds)
            {
                var newDataPengajaran = new MDataPengajaran
                {
                    IdGuru = guru.Id,
                    IdTupleMataPelajaranKelas = idTupleMataPelajaranKelas
                };

                gemilangDbContext.DataPengajaran.Add(newDataPengajaran);
            }

            await gemilangDbContext.SaveChangesAsync();
        }

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexGuru(navigasiService) { Dock = DockStyle.Fill });
    }
}
