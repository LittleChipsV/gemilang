using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages.Guru;
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
using MTopik = Gemilang.Models.Topik;
using MTupleMataPelajaranKelas = Gemilang.Models.TupleMataPelajaranKelas;
using MMataPelajaran = Gemilang.Models.MataPelajaran;
using MKelas = Gemilang.Models.Kelas;
using MGuru = Gemilang.Models.Kelas;

namespace Gemilang.Views.Pages.Topik
{
    public partial class PageIndexTopik : UserControl
    {
        record TopikDTO(int Id, string Nama, string MataPelajaranKelas);

        private List<TopikDTO> daftarTopik;
        private GemilangDbContext gemilangDbContext;
        private NavigasiService navigasiService;

        private MTupleMataPelajaranKelas mataPelajaranKelasPilihan;

        public PageIndexTopik(NavigasiService navigasiService, MTupleMataPelajaranKelas mataPelajaraneKelas)
        {
            InitializeComponent();

            gemilangDbContext = new GemilangDbContext();
            this.navigasiService = navigasiService;

            mataPelajaranKelasPilihan = mataPelajaraneKelas;

            InitializeData();
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();


        private void buttonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahEditTopik(navigasiService, gemilangDbContext, mataPelajaranKelasPilihan));

        private void InitializeData()
        {
            LoadDataTopikAsync();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            textBoxSearch.TextChanged += FilterDataGridView_Event;
        }

        private void LoadDataTopikAsync()
        {
            daftarTopik = gemilangDbContext.Topik
                .Include(t => t.TupleMataPelajaranKelas)
                    .ThenInclude(t => t.MataPelajaran)
                .Include(t => t.TupleMataPelajaranKelas)
                    .ThenInclude(t => t.Kelas)
                .Where(t => t.IdTupleMataPelajaranKelas == mataPelajaranKelasPilihan.Id)
                .OrderBy(t => t.Id)
                .Select(t => new TopikDTO(t.Id, t.Nama, $"{t.TupleMataPelajaranKelas.MataPelajaran.Nama} | {t.TupleMataPelajaranKelas.Kelas.Nama}"))
                .ToList();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarTopik;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarTopik;
            }
        }

        //private void LoadTupleMataPelajaranKelas()
        //{
        //    var tupleMataPelajaranKelas = gemilangDbContext.TupleMataPelajaranKelas
        //       .Include(tmk => tmk.MataPelajaran)
        //       .Include(tmk => tmk.Kelas)
        //       .Where(t => idMapelKelasGuru.Contains(t.Id))
        //       .ToList();

        //    tupleMataPelajaranKelas.Insert(0, new MTupleMataPelajaranKelas { Id = 0, MataPelajaran = new MMataPelajaran { Nama = "Semua mapel" }, Kelas = new MKelas { Nama = "Semua kelas" } });

        //    if (comboBoxFilterMataPelajaranKelas.InvokeRequired)
        //    {
        //        comboBoxFilterMataPelajaranKelas.Invoke(new Action(() =>
        //        {
        //            comboBoxFilterMataPelajaranKelas.DataSource = tupleMataPelajaranKelas;
        //            comboBoxFilterMataPelajaranKelas.DisplayMember = "DisplayTuple";
        //            comboBoxFilterMataPelajaranKelas.ValueMember = "Id";
        //        }));
        //    }
        //    else
        //    {
        //        comboBoxFilterMataPelajaranKelas.DataSource = tupleMataPelajaranKelas;
        //        comboBoxFilterMataPelajaranKelas.DisplayMember = "DisplayTuple";
        //        comboBoxFilterMataPelajaranKelas.ValueMember = "Id";
        //    }
        //}

        private async Task<List<TopikDTO>> FilterDataAsync(string searchText, int idMataPelajaranKelas)
        {
            var query = gemilangDbContext.Topik
                .Include(t => t.TupleMataPelajaranKelas)
                    .ThenInclude(t => t.MataPelajaran)
                .Include(t => t.TupleMataPelajaranKelas)
                    .ThenInclude(t => t.Kelas)
                .Where(t => t.TupleMataPelajaranKelas.Id == idMataPelajaranKelas)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower();
                query = query.Where(t => t.Nama.ToLower().Contains(searchText) ||
                                         t.TupleMataPelajaranKelas.MataPelajaran.Nama.ToLower().Contains(searchText) ||
                                         t.TupleMataPelajaranKelas.Kelas.Nama.ToLower().Contains(searchText));
            }

            return await query.Select(t => new TopikDTO(t.Id, t.Nama, $"{t.TupleMataPelajaranKelas.MataPelajaran.Nama} | {t.TupleMataPelajaranKelas.Kelas.Nama}")).ToListAsync();
        }

        private async Task FilterDataGridViewAsync()
        {
            var searchText = textBoxSearch.Text.ToLower();
            var dataFilter = await FilterDataAsync(searchText, mataPelajaranKelasPilihan.Id);

            dataGridView.DataSource = dataFilter;
        }

        private void ButtonEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;

                var topik = gemilangDbContext.Topik.Find(id);
                navigasiService.Navigasi(new PageTambahEditTopik(navigasiService, gemilangDbContext, mataPelajaranKelasPilihan, topik));
            }
            else MessageBox.Show("Pilih dulu data yang mau diedit di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void ButtonDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Apakah kamu yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                    var topik = await gemilangDbContext.Topik.FindAsync(id);

                    if (topik != null)
                    {
                        gemilangDbContext.Topik.Remove(topik);
                        await gemilangDbContext.SaveChangesAsync();
                        LoadDataTopikAsync();
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau dihapus di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
