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
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Model = Gemilang.Models;

namespace Gemilang.Views.Pages.Nilai
{
    public record NilaiPrintDTO(string NamaTopik, byte Nilai);

    public partial class PageIndexNilai : UserControl
    {
        record NilaiDTO(int Id, string NamaSiswa, string Topik, byte Nilai);

        private GemilangDbContext gemilangDb;
        private Model.TupleMataPelajaranKelas mataPelajaranKelasPilihan;
        private NavigasiService navigasiService;
        private User userSekarang;

        List<NilaiPrintDTO> listNilaiPrintDTO;
        PagePrintNilai pagePrintNilai;

        public PageIndexNilai(NavigasiService navigasiService, Model.TupleMataPelajaranKelas mataPelajaranKelasPilihan, User user)
        {
            InitializeComponent();

            this.navigasiService = navigasiService;
            userSekarang = user;
            this.mataPelajaranKelasPilihan = mataPelajaranKelasPilihan;

            gemilangDb = new GemilangDbContext();
            buttonTambah.Visible = buttonEdit.Visible = buttonHapus.Visible = user is Model.Guru;

            Task.Run(() => InitializeDataAsync(user));
        }

        private async void FilterDataGridView_Event(object? sender, EventArgs e) => await FilterDataGridViewAsync();

        private void buttonTambah_Click(object? sender, EventArgs e) => navigasiService.Navigasi(new PageTambahEditNilai(navigasiService, gemilangDb, mataPelajaranKelasPilihan, userSekarang));


        private async Task InitializeDataAsync(User user)
        {
            await LoadNilaiSiswaAsync(user);
            await LoadDataTopik();

            DataGridViewStyleSetter.SetStyle(dataGridView);

            textBoxSearch.TextChanged += FilterDataGridView_Event;
            comboBoxFilterTopik.SelectedIndexChanged += FilterDataGridView_Event;
        }

        private async Task LoadNilaiSiswaAsync(User user)
        {
            var nilaiSiswaList = await GetNilaiSiswa(user);
            var nilaiSiswaDTOList = nilaiSiswaList.Select(ns => new NilaiDTO(ns.Id, ns.Siswa.Username, ns.Topik.Nama, ns.Nilai)).ToList();

            listNilaiPrintDTO = nilaiSiswaList.Select(ns => new NilaiPrintDTO(ns.Topik.Nama, ns.Nilai)).ToList();

            bool kondisi = nilaiSiswaList.Count != 0 && userSekarang is Model.Siswa;

            if (buttonPrint.InvokeRequired)
            {
                buttonPrint.Invoke(new Action(() => buttonPrint.Visible = kondisi));
            }
            else buttonPrint.Visible = kondisi;

            if (buttonStatistik.InvokeRequired)
            {
                buttonStatistik.Invoke(new Action(() => buttonStatistik.Visible = kondisi));
            }
            else buttonStatistik.Visible = kondisi;


            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = nilaiSiswaDTOList;
                }));
            }
            else
            {
                dataGridView.DataSource = nilaiSiswaDTOList;
            }
        }

        private async Task<List<NilaiSiswa>> GetNilaiSiswa(User user)
        {
            if (user is Model.Guru guru)
            {
                var idTopikPengajaran = await gemilangDb.DataPengajaran
                     .Where(dp => dp.IdGuru == guru.Id && dp.IdTupleMataPelajaranKelas == mataPelajaranKelasPilihan.Id)
                     .SelectMany(dp => dp.TupleMataPelajaranKelas.ListTopik.Select(t => t.Id))
                     .ToListAsync();

                return await gemilangDb.NilaiSiswa
                    .Where(ns => idTopikPengajaran.Contains(ns.IdTopik))
                    .Include(ns => ns.Topik)
                        .ThenInclude(t => t.TupleMataPelajaranKelas)
                            .ThenInclude(tmk => tmk.MataPelajaran)
                    .Include(ns => ns.Topik)
                        .ThenInclude(t => t.TupleMataPelajaranKelas)
                            .ThenInclude(tmk => tmk.Kelas)
                    .Include(ns => ns.Siswa)
                    .ToListAsync();
            }
            else if (user is Model.Siswa siswa)
            {
                return await gemilangDb.NilaiSiswa
                    .Where(ns => ns.IdSiswa == siswa.Id && ns.Topik.IdTupleMataPelajaranKelas == mataPelajaranKelasPilihan.Id)
                    .Include(ns => ns.Topik)
                        .ThenInclude(t => t.TupleMataPelajaranKelas)
                            .ThenInclude(tmk => tmk.MataPelajaran)
                    .Include(ns => ns.Topik)
                        .ThenInclude(t => t.TupleMataPelajaranKelas)
                            .ThenInclude(tmk => tmk.Kelas)
                    .Include(ns => ns.Siswa)
                    .ToListAsync();
            }
            else
            {
                return new List<NilaiSiswa>();
            }
        }

        private async Task LoadDataTopik()
        {
            var topik = await gemilangDb.Topik
               .Include(t => t.TupleMataPelajaranKelas)
               .Where(t => t.IdTupleMataPelajaranKelas == mataPelajaranKelasPilihan.Id)
               .ToListAsync();

            topik.Insert(0, new Model.Topik() { Nama = "Pilih topik", IdTupleMataPelajaranKelas = 0 });

            if (comboBoxFilterTopik.InvokeRequired)
            {
                comboBoxFilterTopik.Invoke(new Action(() =>
                {
                    comboBoxFilterTopik.DataSource = topik;
                    comboBoxFilterTopik.DisplayMember = "Nama";
                    comboBoxFilterTopik.ValueMember = "Id";
                }));
            }
            else
            {
                comboBoxFilterTopik.DataSource = topik;
                comboBoxFilterTopik.DisplayMember = "Nama";
                comboBoxFilterTopik.ValueMember = "Id";
            }
        }

        private async Task<List<NilaiDTO>> FilterDataAsync(string searchText, int idTopik)
        {
            var query = gemilangDb.NilaiSiswa.Where(ns => ns.Topik.IdTupleMataPelajaranKelas == mataPelajaranKelasPilihan.Id).AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(ns => ns.Topik.Nama.ToLower().Contains(searchText) || ns.Siswa.Username.ToLower().Contains(searchText));

            if (idTopik != 0)
                query = query.Where(ns => ns.IdTopik == idTopik);

            return await query.Select(ns => new NilaiDTO(ns.Id, ns.Siswa.Username, ns.Topik.Nama, ns.Nilai)).ToListAsync();
        }

        private async Task FilterDataGridViewAsync()
        {
            var searchText = textBoxSearch.Text.ToLower();
            var idTopikYangDipilih = ((Model.Topik)comboBoxFilterTopik.SelectedItem)?.Id ?? 0;

            var dataFilter = await FilterDataAsync(searchText, idTopikYangDipilih);

            dataGridView.DataSource = dataFilter;
        }

        private void ButtonEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                var nilai = gemilangDb.NilaiSiswa.Find(id);

                navigasiService.Navigasi(new PageTambahEditNilai(navigasiService, gemilangDb, mataPelajaranKelasPilihan, userSekarang, nilai));
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
                    var nilai = await gemilangDb.NilaiSiswa.FindAsync(id);

                    if (nilai != null)
                    {
                        gemilangDb.NilaiSiswa.Remove(nilai);
                        await gemilangDb.SaveChangesAsync();
                        await LoadNilaiSiswaAsync(userSekarang);
                    }
                }
            }
            else MessageBox.Show("Pilih dulu data yang mau dihapus di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string namaKelas = gemilangDb.Siswa
            .Include(s => s.Kelas)
            .FirstOrDefault(s => s.Id == userSekarang.Id).Kelas.Nama;

            pagePrintNilai = new PagePrintNilai();
            pagePrintNilai.SetLabels(userSekarang.Username, namaKelas, mataPelajaranKelasPilihan.MataPelajaran.Nama);
            pagePrintNilai.Dock = DockStyle.Fill;
            pagePrintNilai.SetDataGridView(listNilaiPrintDTO);

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;
            printPreviewDialog.ShowDialog();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(pagePrintNilai.Width, pagePrintNilai.Height);
            pagePrintNilai.DrawToBitmap(bmp, new Rectangle(0, 0, pagePrintNilai.Width, pagePrintNilai.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        private void buttonStatistik_Click(object sender, EventArgs e)
        {
            Statistik pageStatistik = new Statistik(mataPelajaranKelasPilihan, (Models.Siswa)userSekarang);
            pageStatistik.Show();
        }
    }
}