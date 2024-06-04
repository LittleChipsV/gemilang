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
using System.Threading.Tasks;
using System.Windows.Forms;
using MTupleMataPelajaranKelas = Gemilang.Models.TupleMataPelajaranKelas;
using MMataPelajaran = Gemilang.Models.MataPelajaran;
using MKelas = Gemilang.Models.Kelas;

namespace Gemilang.Views.Pages.Guru
{
    public partial class PageIndexGuru : UserControl
    {
        record GuruDTO(int Id, string Nama, string Email, string MataPelajaranKelas);

        private List<GuruDTO> daftarGuru;
        private GemilangDbContext gemilangDbContext;
        private NavigasiService navigasiService;

        public PageIndexGuru(NavigasiService navigasiService)
        {
            InitializeComponent();

            gemilangDbContext = new GemilangDbContext();
            this.navigasiService = navigasiService;

            Task.Run(InitializeDataAsync);
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();

        private void ButtonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahEditGuru(navigasiService, gemilangDbContext) { Dock = DockStyle.Fill });

        private async Task InitializeDataAsync()
        {
            await LoadDataGuruAsync();
            await LoadTupleMataPelajaranKelas();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            textBoxSearch.TextChanged += FilterDataGridView_Event;
            comboBoxFilterMataPelajaran.SelectedIndexChanged += FilterDataGridView_Event;
        }

        private async Task LoadDataGuruAsync()
        {
            var guru = await gemilangDbContext.Guru
               .OrderBy(g => g.Id)
               .Include(g => g.ListDataPengajaran)
                   .ThenInclude(dp => dp.TupleMataPelajaranKelas)
                        .ThenInclude(tmk => tmk.MataPelajaran)
               .Include(g => g.ListDataPengajaran)
                   .ThenInclude(dp => dp.TupleMataPelajaranKelas)
                        .ThenInclude(tmk => tmk.Kelas)
               .ToListAsync();

            daftarGuru = guru.Select(g => new GuruDTO(
                g.Id,
                g.Username,
                g.Email,
                string.Join("\n", g.ListDataPengajaran.Select(dp => $"{dp.TupleMataPelajaranKelas.MataPelajaran.Nama} | {dp.TupleMataPelajaranKelas.Kelas.Nama}"))
            )).ToList();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarGuru;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarGuru;
            }
        }

        private async Task LoadTupleMataPelajaranKelas()
        {
            var tupleMataPelajaranKelas = await gemilangDbContext.TupleMataPelajaranKelas
               .Include(tmk => tmk.MataPelajaran)
               .Include(tmk => tmk.Kelas)
               .ToListAsync();

            tupleMataPelajaranKelas.Insert(0, new MTupleMataPelajaranKelas { Id = 0, MataPelajaran = new MMataPelajaran { Nama = "Semua mapel" }, Kelas = new MKelas { Nama = "Semua kelas" } });

            if (comboBoxFilterMataPelajaran.InvokeRequired)
            {
                comboBoxFilterMataPelajaran.Invoke(new Action(() =>
                {
                    comboBoxFilterMataPelajaran.DataSource = tupleMataPelajaranKelas;
                    comboBoxFilterMataPelajaran.DisplayMember = "DisplayTuple";
                    comboBoxFilterMataPelajaran.ValueMember = "Id";
                }));
            }
            else
            {
                comboBoxFilterMataPelajaran.DataSource = tupleMataPelajaranKelas;
                comboBoxFilterMataPelajaran.DisplayMember = "DisplayTuple";
                comboBoxFilterMataPelajaran.ValueMember = "Id";
            }
        }

        private async Task<List<GuruDTO>> FilterDataAsync(string searchText, int idTupleMataPelajaranKelas)
        {
            var query = gemilangDbContext.Guru.Include(g => g.ListDataPengajaran).ThenInclude(dp => dp.TupleMataPelajaranKelas).AsQueryable();

            if (idTupleMataPelajaranKelas != 0)
                query = query.Where(g => g.ListDataPengajaran.Any(dp => dp.IdTupleMataPelajaranKelas == idTupleMataPelajaranKelas));

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(g => g.Username.ToLower().Contains(searchText) || g.Email.ToLower().Contains(searchText));

            var daftarGuru = await query.OrderBy(g => g.Id)
                .Include(g => g.ListDataPengajaran)
                    .ThenInclude(dp => dp.TupleMataPelajaranKelas)
                        .ThenInclude(tmk => tmk.MataPelajaran)
                .Include(g => g.ListDataPengajaran)
                    .ThenInclude(dp => dp.TupleMataPelajaranKelas)
                        .ThenInclude(tmk => tmk.Kelas)
                .ToListAsync();

            return daftarGuru.Select(g => new GuruDTO(
                g.Id,
                g.Username,
                g.Email,
                string.Join("\n", g.ListDataPengajaran.Select(dp => $"{dp.TupleMataPelajaranKelas.MataPelajaran.Nama} | {dp.TupleMataPelajaranKelas.Kelas.Nama}"))
            )).ToList();
        }

        private async Task FilterDataGridViewAsync()
        {
            var searchText = textBoxSearch.Text.ToLower();
            var idTupleFilter = ((MTupleMataPelajaranKelas)comboBoxFilterMataPelajaran.SelectedItem)?.Id ?? 0;

            var filterData = await FilterDataAsync(searchText, idTupleFilter);
            dataGridView.DataSource = filterData;
        }

        private void ButtonEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;

                var guru = gemilangDbContext.Guru.Find(id);
                navigasiService.Navigasi(new PageTambahEditGuru(navigasiService, gemilangDbContext, guru));
            }
            else MessageBox.Show("Pilih dulu data yang mau diedit di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void ButtonHapus_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Apakah kamu yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                    var guru = await gemilangDbContext.Guru.FindAsync(id);

                    if (guru != null)
                    {
                        gemilangDbContext.Guru.Remove(guru);
                        await gemilangDbContext.SaveChangesAsync();
                        await LoadDataGuruAsync();
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau dihapus di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}