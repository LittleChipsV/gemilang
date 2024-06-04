using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages.MataPelajaran;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTupleMataPelajaranKelas = Gemilang.Models.TupleMataPelajaranKelas;
using MKelas = Gemilang.Models.Kelas;
using MMataPelajaran = Gemilang.Models.MataPelajaran;

namespace Gemilang.Views.Pages.TupleMataPelajaranKelas
{
    public partial class PageTambahEditTupleMataPelajaranKelas : UserControl
    {
        private readonly NavigasiService navigasiService;
        private readonly GemilangDbContext gemilangDbContext;
        private readonly MTupleMataPelajaranKelas? tupleMataPelajaranKelas;

        public PageTambahEditTupleMataPelajaranKelas(NavigasiService navigasiService, GemilangDbContext gemilangDbContext, MTupleMataPelajaranKelas? tupleMataPelajaranKelas = null)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            this.gemilangDbContext = gemilangDbContext;
            this.tupleMataPelajaranKelas = tupleMataPelajaranKelas;

            buttonCancel.Click += buttonCancel_Click;
            buttonTambah.Click += buttonTambah_Click;

            LoadDataKelas();
            LoadDataMataPelajaran();

            if (tupleMataPelajaranKelas != null)
                SetUpPageEditForm();
        }

        private async void buttonTambah_Click(object? sender, EventArgs e)
        {
            int idMataPelajaran = comboBoxMataPelajaran.SelectedValue == null ? 0 : (int)comboBoxMataPelajaran.SelectedValue;
            int idKelas = comboBoxKelas.SelectedValue == null ? 0 : (int)comboBoxKelas.SelectedValue;

            if (comboBoxKelas.SelectedIndex == 0 || comboBoxMataPelajaran.SelectedIndex == 0)
                ShowPesanWarning("Masukkan input dengan lengkap");
            else if (gemilangDbContext.TupleMataPelajaranKelas.FirstOrDefault(tmk => tmk.IdMataPelajaran == idMataPelajaran && tmk.IdKelas == idKelas) != null)
                ShowPesanWarning("Sudah ada data yang sama");
            else
            {
                if (tupleMataPelajaranKelas == null)
                    await Tambah(idMataPelajaran, idKelas);
                else
                    await Update(tupleMataPelajaranKelas, idMataPelajaran, idKelas);

                ShowPesanInfo($"Berhasil {(tupleMataPelajaranKelas == null ? "menambah" : "mengupdate")} tuple mata pelajaran - kelas!");
                BalikKeHalamanIndex();
            }
        }

        private void buttonCancel_Click(object? sender, EventArgs e) => BalikKeHalamanIndex();



        private void SetUpPageEditForm()
        {
            labelJudul.Text = "Edit Tuple Mapel - Kelas";
            buttonTambah.Text = "Edit";
        }

        private void LoadDataMataPelajaran()
        {
            var mataPelajaran = gemilangDbContext.MataPelajaran.ToList();
            mataPelajaran.Insert(0, new MMataPelajaran{ Nama = "Pilih Mata Pelajaran" });

            comboBoxMataPelajaran.DataSource = mataPelajaran;
            comboBoxMataPelajaran.DisplayMember = "Nama";
            comboBoxMataPelajaran.ValueMember = "Id";

            if (tupleMataPelajaranKelas != null)
                comboBoxMataPelajaran.SelectedValue = tupleMataPelajaranKelas.IdMataPelajaran;
        }

        private void LoadDataKelas()
        {
            var kelas = gemilangDbContext.Kelas.ToList();
            kelas.Insert(0, new MKelas { Nama = "Pilih kelas" });

            comboBoxKelas.DataSource = kelas;
            comboBoxKelas.DisplayMember = "Nama";
            comboBoxKelas.ValueMember = "Id";

            if (tupleMataPelajaranKelas != null)
                comboBoxKelas.SelectedValue = tupleMataPelajaranKelas.IdKelas;
        }

        //private async Task LoadDataTupleMataPelajaranKelas()
        //{
        //    var tupleData = await gemilangDbContext.TupleMataPelajaranKelas
        //                               .Include(t => t.MataPelajaran)
        //                               .Include(t => t.Kelas)
        //                               .ToListAsync();

        //    var mataPelajaranList = tupleData.Select(t => t.MataPelajaran).Distinct().ToList();
        //    var kelasList = tupleData.Select(t => t.Kelas).Distinct().ToList();

        //    mataPelajaranList.Insert(0, new MMataPelajaran { Id = 0, Nama = "Pilih Mata Pelajaran" });
        //    kelasList.Insert(0, new MKelas{ Id = 0, Nama = "Pilih Kelas" });

        //    if (comboBoxMataPelajaran.InvokeRequired)
        //    {
        //        comboBoxMataPelajaran.Invoke(new Action(() =>
        //        {
        //            comboBoxMataPelajaran.DataSource = mataPelajaranList;
        //            comboBoxMataPelajaran.DisplayMember = "Nama";
        //            comboBoxMataPelajaran.ValueMember = "Id";
        //        }));
        //    }
        //    else
        //    {
        //        comboBoxMataPelajaran.DataSource = mataPelajaranList;
        //        comboBoxMataPelajaran.DisplayMember = "Nama";
        //        comboBoxMataPelajaran.ValueMember = "Id";
        //    }

        //    if (comboBoxKelas.InvokeRequired)
        //    {
        //        comboBoxKelas.Invoke(new Action(() =>
        //        {
        //            comboBoxKelas.DataSource = kelasList;
        //            comboBoxKelas.DisplayMember = "Nama";
        //            comboBoxKelas.ValueMember = "Id";
        //        }));
        //    }
        //    else
        //    {
        //        comboBoxKelas.DataSource = kelasList;
        //        comboBoxKelas.DisplayMember = "Nama";
        //        comboBoxKelas.ValueMember = "Id";
        //    }

        //    if (tupleMataPelajaranKelas != null)
        //    {
        //        comboBoxKelas.SelectedValue = tupleMataPelajaranKelas.IdKelas;
        //        comboBoxMataPelajaran.SelectedValue = tupleMataPelajaranKelas.IdMataPelajaran;
        //    }
        //}

        //private async Task LoadDataKelas()
        //{
        //    var kelas = await gemilangDbContext.Kelas.ToListAsync();
        //    kelas.Insert(0, new MKelas { Nama = "Pilih kelas" });

        //    comboBoxKelas.DataSource = kelas;
        //    comboBoxKelas.DisplayMember = "Nama";
        //    comboBoxKelas.ValueMember = "Id";

        //    if (tupleMataPelajaranKelas != null)
        //        comboBoxKelas.SelectedValue = tupleMataPelajaranKelas.IdKelas;
        //}

        //private async Task LoadDataMataPelajaran()
        //{
        //    var mataPelajaran = await gemilangDbContext.MataPelajaran.ToListAsync();
        //    mataPelajaran.Insert(0, new MMataPelajaran { Nama = "Pilih mata pelajaran" });

        //    comboBoxKelas.DataSource = mataPelajaran;
        //    comboBoxKelas.DisplayMember = "Nama";
        //    comboBoxKelas.ValueMember = "Id";

        //    if (tupleMataPelajaranKelas != null)
        //        comboBoxMataPelajaran.SelectedValue = tupleMataPelajaranKelas.IdMataPelajaran;
        //}

        private async Task Tambah(int idMataPelajaran, int idKelas)
        {
            gemilangDbContext.TupleMataPelajaranKelas.Add(new MTupleMataPelajaranKelas
            {
                IdMataPelajaran = idMataPelajaran,
                IdKelas = idKelas
            });

            await gemilangDbContext.SaveChangesAsync();
        }

        private async Task Update(MTupleMataPelajaranKelas tupleMataPelajaranKelas, int idMataPelajaran, int idKelas)
        {
            tupleMataPelajaranKelas.IdMataPelajaran = idMataPelajaran;
            tupleMataPelajaranKelas.IdKelas = idKelas;

            await gemilangDbContext.SaveChangesAsync();
        }

        private void ShowPesanWarning(string message) => MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowPesanInfo(string message) => MessageBox.Show(message, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BalikKeHalamanIndex() => navigasiService.Navigasi(new PageIndexTupleMataPelajaranKelas(navigasiService) { Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom });
    }
}
