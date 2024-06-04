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
using MKelas = Gemilang.Models.Kelas;

namespace Gemilang.Views.Pages.Kelas
{
    public partial class PageTambahEditKelas : UserControl
    {
        private readonly NavigasiService navigasiService;
        private readonly GemilangDbContext gemilangDbContext;
        private readonly MKelas kelas;

        public PageTambahEditKelas(NavigasiService navigasiService, GemilangDbContext gemilangDbContext, MKelas kelas = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            this.gemilangDbContext = gemilangDbContext;
            this.kelas = kelas;

            buttonCancel.Click += buttonCancel_Click;
            buttonTambah.Click += buttonTambah_Click;
            
            if (kelas != null)
                SetUpPageEditForm();

        }

        private async void buttonTambah_Click(object? sender, EventArgs e)
        {
            string namaKelas = textBoxNamaKelas.Text;

            if (string.IsNullOrEmpty(namaKelas))
                ShowPesanWarning("Isi nama kelas");
            if (gemilangDbContext.Kelas.FirstOrDefault(k => k.Nama == namaKelas) != null)
                ShowPesanWarning("Nama kelas sudah dipakai");
            else
            {
                if (kelas == null)
                    await Tambah(namaKelas);
                else
                    await Update(kelas, namaKelas);

                ShowPesanInfo($"Berhasil {(kelas == null ? "menambah" : "mengupdate")} kelas!");
                BalikKeHalamanIndex();
            }
        }

        private void buttonCancel_Click(object? sender, EventArgs e) => BalikKeHalamanIndex();



        private void SetUpPageEditForm()
        {
            labelJudul.Text = "Edit Kelas";
            buttonTambah.Text = "Edit";

            textBoxNamaKelas.Text = kelas.Nama;
        }

        private async Task Tambah(string namaKelas)
        {
            gemilangDbContext.Kelas.Add(new MKelas
            {
                Nama = namaKelas
            });

            await gemilangDbContext.SaveChangesAsync();
        }

        private async Task Update(MKelas kelas, string namaKelas)
        {
            kelas.Nama = namaKelas;

            await gemilangDbContext.SaveChangesAsync();
        }

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexKelas(navigasiService));
    }
}
