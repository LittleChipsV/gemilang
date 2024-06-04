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
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace Gemilang.Views.Pages.Kelas
{
    public partial class PageIndexKelas : UserControl
    {
        record KelasDTO(int Id, string Nama);

        private GemilangDbContext gemilangDb;
        private List<KelasDTO> daftarKelas;
        private NavigasiService navigasiService;

        public PageIndexKelas(NavigasiService navigasiService)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            gemilangDb = new GemilangDbContext();

            Task.Run(InitializeDataAsync);
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();

        private void buttonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahEditKelas(navigasiService, gemilangDb));


        private async Task InitializeDataAsync()
        {
            await LoadDataKelasAsync();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            textBoxSearch.TextChanged += FilterDataGridView_Event;
        }

        private async Task LoadDataKelasAsync()
        {
            daftarKelas = await gemilangDb.Kelas
               .OrderBy(s => s.Id)
               .Select(k => new KelasDTO(k.Id, k.Nama))
               .ToListAsync();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarKelas;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarKelas;
            }
        }

        private async Task<List<KelasDTO>> FilterDataAsync(string searchText)
        {
            var query = gemilangDb.Kelas.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(k => k.Nama.ToLower().Contains(searchText));

            return await query.Select(k => new KelasDTO(k.Id, k.Nama)).ToListAsync();
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
                var kelas = gemilangDb.Kelas.Find(id);

                navigasiService.Navigasi(new PageTambahEditKelas(navigasiService, gemilangDb, kelas));
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
                    var kelas = await gemilangDb.Kelas.FindAsync(id);

                    if (kelas != null)
                    {
                        gemilangDb.Kelas.Remove(kelas);
                        await gemilangDb.SaveChangesAsync();
                        await LoadDataKelasAsync();
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau diedit di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}