using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages.MataPelajaran;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Model = Gemilang.Models;

namespace Gemilang.Views.Pages.Nilai
{
    public partial class PageTambahEditNilai : UserControl
    {
        private GemilangDbContext gemilangDb;
        private NavigasiService navigasiService;
        private Model.TupleMataPelajaranKelas tupleMataPelajaranYangDipilih;
        private NilaiSiswa? nilaiSiswa;
        private User userSekarang;

        public PageTambahEditNilai(NavigasiService navigasiService, GemilangDbContext gemilangDbContext, Model.TupleMataPelajaranKelas tupleMataPelajaranKelas, User user, NilaiSiswa? nilaiSiswa = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            gemilangDb = gemilangDbContext;
            this.nilaiSiswa = nilaiSiswa;
            tupleMataPelajaranYangDipilih = tupleMataPelajaranKelas;
            userSekarang = user;

            LoadDataTopik();
            LoadDataSiswa();

            buttonCancel.Click += ButtonCancel_Click;
            buttonTambah.Click += ButtonTambah_Click;

            if (nilaiSiswa != null)
            {
                SetUpFormEdit();
            }
        }

        private void LoadDataTopik()
        {
            var topikList = gemilangDb.Topik
                .Include(t => t.TupleMataPelajaranKelas)
                    .ThenInclude(tmk => tmk.MataPelajaran)
                .Include(t => t.TupleMataPelajaranKelas)
                    .ThenInclude(tmk => tmk.Kelas)
                .Where(t => t.IdTupleMataPelajaranKelas == tupleMataPelajaranYangDipilih.Id)
                .ToList();

            topikList.Insert(0, new Model.Topik() { Nama = "Pilih topik", IdTupleMataPelajaranKelas = 0 });
            comboBoxTopik.DataSource = topikList;
            comboBoxTopik.DisplayMember = "Nama";
            comboBoxTopik.ValueMember = "Id";

            var kelasList = gemilangDb.Kelas.ToList();
            kelasList.Insert(0, new Model.Kelas() { Nama = "Pilih kelas" });

            if (nilaiSiswa != null)
            {
                comboBoxTopik.SelectedValue = nilaiSiswa.IdTopik;
            }
        }

        private void LoadDataSiswa()
        {
            var siswaList = gemilangDb.Siswa
                    .Where(s => s.IdKelas == tupleMataPelajaranYangDipilih.IdKelas)
                    .ToList();

            siswaList.Insert(0, new Model.Siswa() { Username = $"Pilih siswa kelas: {tupleMataPelajaranYangDipilih.Kelas.Nama}" });
            comboBoxSiswa.DataSource = siswaList;
            comboBoxSiswa.DisplayMember = "Username";
            comboBoxSiswa.ValueMember = "Id";

            if (nilaiSiswa != null)
            {
                comboBoxSiswa.SelectedValue = nilaiSiswa.IdSiswa;
            }
        }

        private void SetUpFormEdit()
        {
            buttonTambah.Text = "Edit";
            labelJudul.Text = "Edit Nilai";

            numericUpDownNilai.Value = nilaiSiswa!.Nilai;
        }

        private async void ButtonTambah_Click(object sender, EventArgs e)
        {
            int idTopikYangDipilih = (int)comboBoxTopik.SelectedValue;
            int idSiswaYangDipilih = (int)comboBoxSiswa.SelectedValue;
            byte nilai = (byte)numericUpDownNilai.Value;

            if (idSiswaYangDipilih == 0)
                ShowPesanWarning("Pilih siswa terlebih dahulu");
            else if (idTopikYangDipilih == 0)
                ShowPesanWarning("Pilih topik terlebih dahulu");
            else
            {
                if (nilaiSiswa == null)
                {
                    var nilaiSiswa = new NilaiSiswa
                    {
                        Nilai = nilai,
                        IdSiswa = idSiswaYangDipilih,
                        IdTopik = idTopikYangDipilih
                    };

                    gemilangDb.NilaiSiswa.Add(nilaiSiswa);
                }
                else
                {
                    nilaiSiswa.Nilai = nilai;
                    nilaiSiswa.IdTopik = idTopikYangDipilih;
                    nilaiSiswa.IdSiswa = idSiswaYangDipilih;

                    gemilangDb.NilaiSiswa.Update(nilaiSiswa);
                }

                await gemilangDb.SaveChangesAsync();

                ShowPesanInfo($"Nilai berhasil disimpan!");

                BalikKeHalamanIndex();
            }
        }

        private void ButtonCancel_Click(object? sender, EventArgs e) => BalikKeHalamanIndex();

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexNilai(navigasiService, tupleMataPelajaranYangDipilih, userSekarang));
    }
}
