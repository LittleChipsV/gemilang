using Gemilang.Data;
using Gemilang.Utils;
using Gemilang.Views.Pages.Kelas;
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

namespace Gemilang.Views.Pages.TupleMataPelajaranKelas
{
    public partial class PageIndexTupleMataPelajaranKelas : UserControl
    {
        record TupleMataPelajaranDTO(int Id, string NamaMataPelajaran, string NamaKelas);

        private GemilangDbContext gemilangDbContext;
        private List<TupleMataPelajaranDTO> daftarTupleMapelKelas;
        private NavigasiService navigasiService;

        public PageIndexTupleMataPelajaranKelas(NavigasiService navigasiService)
        {
            InitializeComponent();

            gemilangDbContext = new GemilangDbContext();
            this.navigasiService = navigasiService;

            Task.Run(InitializeDataAsync);
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();

        private void buttonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahEditTupleMataPelajaranKelas(navigasiService, gemilangDbContext));

        private async Task InitializeDataAsync()
        {
            await LoadDataSiswaAsync();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            textBoxSearch.TextChanged += FilterDataGridView_Event;
        }

        private async Task LoadDataSiswaAsync()
        {
            daftarTupleMapelKelas = await gemilangDbContext.TupleMataPelajaranKelas
                .OrderBy(s => s.Id)
                .Select(k => new TupleMataPelajaranDTO(k.Id, k.MataPelajaran.Nama, k.Kelas.Nama))
                .ToListAsync();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarTupleMapelKelas;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarTupleMapelKelas;
            }
        }

        private async Task<List<TupleMataPelajaranDTO>> FilterDataAsync(string searchText)
        {
            var query = gemilangDbContext.TupleMataPelajaranKelas.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(tmk => tmk.MataPelajaran.Nama.ToLower().Contains(searchText) || tmk.Kelas.Nama.ToLower().Contains(searchText));

            return await query.Select(tmk => new TupleMataPelajaranDTO(tmk.Id, tmk.MataPelajaran.Nama, tmk.Kelas.Nama)).ToListAsync();
        }

        private async Task FilterDataGridViewAsync()
        {
            var searchText = textBoxSearch.Text.ToLower();
            var dataFilter = await FilterDataAsync(searchText);

            dataGridView.DataSource = dataFilter;
        }

        private void ButtonEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                var tupleMataPelajaranKelas = gemilangDbContext.TupleMataPelajaranKelas.Find(id);

                navigasiService.Navigasi(new PageTambahEditTupleMataPelajaranKelas(navigasiService, gemilangDbContext, tupleMataPelajaranKelas));
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
                    var tupleMataPelajaranKelas = await gemilangDbContext.TupleMataPelajaranKelas.FindAsync(id);

                    if (tupleMataPelajaranKelas != null)
                    {
                        gemilangDbContext.TupleMataPelajaranKelas.Remove(tupleMataPelajaranKelas);
                        await gemilangDbContext.SaveChangesAsync();
                        await LoadDataSiswaAsync();
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau dihapus di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
