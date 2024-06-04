using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages.Siswa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMataPelajaran = Gemilang.Models.MataPelajaran;

namespace Gemilang.Views.Pages.MataPelajaran
{
    public partial class PageTambahEditMataPelajaran : UserControl
    {
        private readonly NavigasiService navigasiService;
        private readonly GemilangDbContext gemilangDbContext;
        private readonly MMataPelajaran? mataPelajaran;

        public PageTambahEditMataPelajaran(NavigasiService navigasiService, GemilangDbContext gemilangDbContext, MMataPelajaran? mataPelajaran = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            this.gemilangDbContext = gemilangDbContext;
            this.mataPelajaran = mataPelajaran;

            buttonCancel.Click += buttonCancel_Click;
            buttonTambah.Click += buttonTambah_Click;

            if (mataPelajaran != null)
                SetUpPageEditForm();
        }

        private async void buttonTambah_Click(object? sender, EventArgs e)
        {
            string namaMataPelajaran = textBoxNamaMataPelajaran.Text;

            if (string.IsNullOrEmpty(namaMataPelajaran))
                ShowPesanWarning("Isi nama mata pelajaran");
            if (gemilangDbContext.MataPelajaran.FirstOrDefault(k => k.Nama == namaMataPelajaran) != null)
                ShowPesanWarning("Nama mata pelajaran sudah dipakai");
            else
            {
                if (mataPelajaran == null)
                    await Tambah(namaMataPelajaran);
                else
                    await Update(mataPelajaran, namaMataPelajaran);

                ShowPesanInfo($"Berhasil {(mataPelajaran == null ? "menambah" : "mengupdate")} mata pelajaran!");
                BalikKeHalamanIndex();
            }
        }

        private void buttonCancel_Click(object? sender, EventArgs e) => BalikKeHalamanIndex();



        private void SetUpPageEditForm()
        {
            labelJudul.Text = "Edit Mata Pelajaran";
            buttonTambah.Text = "Edit";

            textBoxNamaMataPelajaran.Text = mataPelajaran!.Nama;
        }

        private async Task Tambah(string namaMataPelajaran)
        {
            gemilangDbContext.MataPelajaran.Add(new MMataPelajaran
            {
                Nama = namaMataPelajaran
            });

            await gemilangDbContext.SaveChangesAsync();
        }

        private async Task Update(MMataPelajaran mataPelajaran, string namaMataPelajaran)
        {
            mataPelajaran.Nama = namaMataPelajaran;

            await gemilangDbContext.SaveChangesAsync();
        }

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexMataPelajaran(navigasiService));
    }
}
