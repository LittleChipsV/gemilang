using Gemilang.Data;
using Gemilang.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MTopik = Gemilang.Models.Topik;
using MTupleMataPelajaranKelas = Gemilang.Models.TupleMataPelajaranKelas;
using MKelas = Gemilang.Models.Kelas;
using MMataPelajaran= Gemilang.Models.MataPelajaran;
using Microsoft.EntityFrameworkCore;

namespace Gemilang.Views.Pages.Topik
{
    public partial class PageTambahEditTopik : UserControl
    {
        private readonly MTupleMataPelajaranKelas tupleMataPelajaranKelas;
        private readonly NavigasiService navigasiService;
        private readonly GemilangDbContext gemilangDbContext;
        private readonly MTopik topik;

        public PageTambahEditTopik(NavigasiService navigasiService, GemilangDbContext context, MTupleMataPelajaranKelas tupleMataPelajaranKelas, MTopik topik = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            this.tupleMataPelajaranKelas = tupleMataPelajaranKelas;
            this.topik = topik;
            gemilangDbContext = context;

            buttonCancel.Click += ButtonCancel_Click;
            buttonTambah.Click += ButtonTambah_Click;

            //Task.Run(LoadDataTupleMataPelajaranKelas);

            if (topik != null)
                SetUpPageEditForm();
        }

        //private async Task LoadDataTupleMataPelajaranKelas()
        //{
        //    var tuple = await gemilangDbContext.TupleMataPelajaranKelas
        //        .Include(t => t.MataPelajaran)
        //        .Include(t => t.Kelas)
        //        .ToListAsync();

        //    tuple.Insert(0, new MTupleMataPelajaranKelas { Id = 0, MataPelajaran = new MMataPelajaran { Nama = "Mapel" }, Kelas = new MKelas { Nama = "Kelas" } });

        //    comboBoxMataPelajaranKelas.DataSource = tuple;
        //    comboBoxMataPelajaranKelas.DisplayMember = "DisplayName";
        //    comboBoxMataPelajaranKelas.ValueMember = "Id";

        //    if (topik != null)
        //        comboBoxMataPelajaranKelas.SelectedValue = topik.IdTupleMataPelajaranKelas;
        //}

        private void SetUpPageEditForm()
        {
            labelJudul.Text = "Edit Topik";
            buttonTambah.Text = "Edit";

            textBoxNamaTopik.Text = topik.Nama;
        }

        private void ButtonCancel_Click(object? sender, EventArgs e) => BalikKeHalamanIndex();

        private async void ButtonTambah_Click(object? sender, EventArgs e)
        {
            string namaTopik = textBoxNamaTopik.Text;
            //int idTupleMataPelajaranKelasYangDipilih = comboBoxMataPelajaranKelas.SelectedValue == null ? 0 : (int)comboBoxMataPelajaranKelas.SelectedValue;

            if (namaTopik.Length < 4)
                ShowPesanWarning("Nama topik minimal harus berjumlah 4 karakter");
            else
            {
                if (topik == null)
                {
                    await Tambah(namaTopik);
                }
                else
                {
                    await Update(topik, namaTopik);
                }

                ShowPesanInfo($"Berhasil {(topik == null ? "menambah" : "mengupdate")} topik!");
                BalikKeHalamanIndex();
            }
        }

        private async Task Tambah(string nama)
        {
            gemilangDbContext.Topik.Add(new MTopik
            {
                Nama = nama,
                IdTupleMataPelajaranKelas = tupleMataPelajaranKelas.Id
            });

            await gemilangDbContext.SaveChangesAsync();
        }

        private async Task Update(MTopik topik, string nama)
        {
            topik.Nama = nama;

            await gemilangDbContext.SaveChangesAsync();
        }

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexTopik(navigasiService, tupleMataPelajaranKelas));
    }
}
