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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gemilang.Views.Pages.MataPelajaran
{
    public partial class PageIndexMataPelajaran : UserControl
    {
        record MataPelajaranDTO(int Id, string Nama);

        private GemilangDbContext gemilangDb;
        private List<MataPelajaranDTO> daftarMataPelajaran;
        private NavigasiService navigasiService;

        public PageIndexMataPelajaran(NavigasiService navigasiService)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            gemilangDb = new GemilangDbContext();

            Task.Run(InitializeDataAsync);
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();

        private void buttonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahEditMataPelajaran(navigasiService, gemilangDb));



        private async Task InitializeDataAsync()
        {
            await LoadDataSiswaAsync();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            textBoxSearch.TextChanged += FilterDataGridView_Event;
            buttonTambah.Click += buttonTambah_Click;
        }

        private async Task LoadDataSiswaAsync()
        {
            daftarMataPelajaran = await gemilangDb.MataPelajaran
                .OrderBy(s => s.Id)
                .Select(m => new MataPelajaranDTO(m.Id, m.Nama))
                .ToListAsync();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarMataPelajaran;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarMataPelajaran;
            }
        }

        private async Task<List<MataPelajaranDTO>> FilterDataAsync(string searchText)
        {
            var query = gemilangDb.MataPelajaran.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(k => k.Nama.ToLower().Contains(searchText));

            return await query.Select(k => new MataPelajaranDTO(k.Id, k.Nama)).ToListAsync();
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

                var mataPelajaran = gemilangDb.MataPelajaran.Find(id);
                navigasiService.Navigasi(new PageTambahEditMataPelajaran(navigasiService, gemilangDb, mataPelajaran));
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
                    var mataPelajaran = await gemilangDb.MataPelajaran.FindAsync(id);

                    if (mataPelajaran != null)
                    {
                        gemilangDb.MataPelajaran.Remove(mataPelajaran);
                        await gemilangDb.SaveChangesAsync();
                        await LoadDataSiswaAsync();
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau dihapus di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
