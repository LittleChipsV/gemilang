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
using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using FontAwesome.Sharp;
using MKelas = Gemilang.Models.Kelas;

namespace Gemilang.Views.Pages.Siswa
{
    public partial class PageIndexSiswa : UserControl
    {
        record SiswaDTO(int Id, string Nama, string Email, string Kelas);

        private List<SiswaDTO> daftarSiswa;
        private GemilangDbContext gemilangDbContext;
        private NavigasiService navigasiService;

        public PageIndexSiswa(NavigasiService navigasiService)
        {
            InitializeComponent();

            gemilangDbContext = new GemilangDbContext();
            this.navigasiService = navigasiService;

            Task.Run(InitializeDataAsync);
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();

        private void buttonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahSiswa(navigasiService, gemilangDbContext) { Dock = DockStyle.Fill });



        private async Task InitializeDataAsync()
        {
            await LoadDataSiswaAsync();
            await LoadDataKelasAsync();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            buttonTambah.Click += buttonTambah_Click;
            textBoxSearch.TextChanged += FilterDataGridView_Event;
            comboBoxFilterKelas.SelectedIndexChanged += FilterDataGridView_Event;
        }

        private async Task LoadDataSiswaAsync()
        {
            daftarSiswa = await gemilangDbContext.Siswa
               .OrderBy(s => s.Id)
               .Select(s => new SiswaDTO(s.Id, s.Username, s.Email, s.Kelas == null ? "-" : s.Kelas.Nama))
               .ToListAsync();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarSiswa;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarSiswa;
            }
        }

        private async Task LoadDataKelasAsync()
        {
            var kelas = await gemilangDbContext.Kelas.Distinct().ToListAsync();
            kelas.Insert(0, new MKelas() { Id = 0, Nama = "Semua Kelas" });

            if (comboBoxFilterKelas.InvokeRequired)
            {
                comboBoxFilterKelas.Invoke(new Action(() =>
                {
                    comboBoxFilterKelas.DataSource = kelas;
                    comboBoxFilterKelas.DisplayMember = "Nama";
                    comboBoxFilterKelas.ValueMember = "Id";
                }));
            }
            else
            {
                comboBoxFilterKelas.DataSource = kelas;
                comboBoxFilterKelas.DisplayMember = "Nama";
                comboBoxFilterKelas.ValueMember = "Id";
            }
        }

        private async Task<List<SiswaDTO>> FilterDataAsync(string searchText, int idKelasYangDipilih)
        {
            var query = gemilangDbContext.Siswa.Include(s => s.Kelas).AsQueryable();

            if (idKelasYangDipilih != 0)
                query = query.Where(s => s.IdKelas == idKelasYangDipilih);
            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(s => s.Username.ToLower().Contains(searchText) || s.Email.ToLower().Contains(searchText));

            return await query.Select(s => new SiswaDTO(s.Id, s.Username, s.Email, s.Kelas == null ? "-" : s.Kelas.Nama)).ToListAsync();
        }

        private async Task FilterDataGridViewAsync()
        {
            var searchText = textBoxSearch.Text.ToLower();
            var idKelasYangDipilih = ((MKelas)comboBoxFilterKelas.SelectedItem)?.Id ?? 0;

            var dataFilter = await FilterDataAsync(searchText, idKelasYangDipilih);
            dataGridView.DataSource = dataFilter;
        }

        private void ButtonEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;

                var siswa = gemilangDbContext.Siswa.Find(id);
                navigasiService.Navigasi(new PageTambahSiswa(navigasiService, gemilangDbContext, siswa) { Dock = DockStyle.Fill });
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
                    var siswa = await gemilangDbContext.Siswa.FindAsync(id);

                    if (siswa != null)
                    {
                        gemilangDbContext.Siswa.Remove(siswa);
                        await gemilangDbContext.SaveChangesAsync();
                        await LoadDataSiswaAsync();
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau dihapus di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
