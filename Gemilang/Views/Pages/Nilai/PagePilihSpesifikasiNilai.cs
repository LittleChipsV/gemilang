using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Gemilang.Views.Pages.Topik;
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

using Model = Gemilang.Models;

namespace Gemilang.Views.Pages.Nilai
{
    public partial class PagePilihSpesifikasiNilai : UserControl
    {
        record SpesifikasiMataPelajaranKelas(int Id, string NamaMataPelajaran, string NamaKelas);

        private GemilangDbContext gemilangDbContext;
        private NavigasiService navigasiService;
        private User user;

        public PagePilihSpesifikasiNilai(NavigasiService navigasiService, User user)
        {
            InitializeComponent();

            gemilangDbContext = new GemilangDbContext();
            this.navigasiService = navigasiService;
            this.user = user;

            InitializeData(user);
        }

        private async Task InitializeData(User user)
        {
            if (user is Model.Guru guru)
                await LoadMataPelajaranKelasGuru(guru.Id);
            else if (user is Model.Siswa siswa)
                await LoadMataPelajaranKelasSiswa(siswa.IdKelas);


            DataGridViewStyleSetter.SetStyle(dataGridView);
        }

        private async Task LoadMataPelajaranKelasGuru(int idGuru)
        {
            var mataPelajaranKelasList = await gemilangDbContext.DataPengajaran
                .Where(dp => dp.IdGuru == idGuru)
                .Include(dp => dp.TupleMataPelajaranKelas)
                    .ThenInclude(tmk => tmk.MataPelajaran)
                .Include(dp => dp.TupleMataPelajaranKelas)
                    .ThenInclude(tmk => tmk.Kelas)
                .Select(dp => new SpesifikasiMataPelajaranKelas(
                    dp.TupleMataPelajaranKelas.Id,
                    dp.TupleMataPelajaranKelas.MataPelajaran.Nama,
                    dp.TupleMataPelajaranKelas.Kelas.Nama))
                .ToListAsync();

            dataGridView.DataSource = mataPelajaranKelasList;
        }

        private async Task LoadMataPelajaranKelasSiswa(int idKelas)
        {
            var mataPelajaranKelasList = await gemilangDbContext.TupleMataPelajaranKelas
                .Where(tmk => tmk.IdKelas == idKelas)
                .Include(tmk => tmk.MataPelajaran)
                .Include(tmk => tmk.Kelas)
                .Select(tmk => new SpesifikasiMataPelajaranKelas(
                    tmk.Id,
                    tmk.MataPelajaran.Nama,
                    tmk.Kelas.Nama))
                .ToListAsync();

            dataGridView.DataSource = mataPelajaranKelasList;
        }

        private void ButtonPilih_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                var mapelKelasPilihan = gemilangDbContext.TupleMataPelajaranKelas
                    .Include(tmk => tmk.Kelas)
                    .Include(tmk => tmk.MataPelajaran)
                    .FirstOrDefault(tmk => tmk.Id == id);

                navigasiService.Navigasi(new PageIndexNilai(navigasiService, mapelKelasPilihan, user));
            }
            else MessageBox.Show("Pilih dulu data di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
