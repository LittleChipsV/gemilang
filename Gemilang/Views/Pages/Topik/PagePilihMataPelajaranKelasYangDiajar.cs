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

using MGuru = Gemilang.Models.Guru;

namespace Gemilang.Views.Pages.Topik
{
    public partial class PagePilihMataPelajaranKelasYangDiajar : UserControl
    {
        record PIlihMapelKelasDTO(int Id, string NamaMataPelajaran, string NamaKelas);

        private List<PIlihMapelKelasDTO> daftarDataPengajaran;
        private GemilangDbContext gemilangDbContext;
        private NavigasiService navigasiService;

        private List<int> idMapelKelasGuru;

        public PagePilihMataPelajaranKelasYangDiajar(NavigasiService navigasiService, MGuru guru)
        {
            InitializeComponent();

            gemilangDbContext = new GemilangDbContext();
            this.navigasiService = navigasiService;

            InitializeData(guru);
        }

        private void InitializeData(MGuru guru)
        {
            LoadIdTupleMataPelajaranKelasByIdGuru(guru.Id);

            LoadDataPengajaran();

            DataGridViewStyleSetter.SetStyle(dataGridView);
        }

        public void LoadIdTupleMataPelajaranKelasByIdGuru(int idGuru)
        {
            idMapelKelasGuru = gemilangDbContext.DataPengajaran
                .Where(dp => dp.IdGuru == idGuru)
                .Select(dp => dp.IdTupleMataPelajaranKelas)
                .ToList();
        }

        private void LoadDataPengajaran()
        {
            daftarDataPengajaran = gemilangDbContext.TupleMataPelajaranKelas
               .Include(tmk => tmk.MataPelajaran)
               .Include(tmk => tmk.Kelas)
               .Where(t => idMapelKelasGuru.Contains(t.Id))
               .Select(tmk => new PIlihMapelKelasDTO(tmk.Id, tmk.MataPelajaran.Nama, tmk.Kelas.Nama))
               .ToList();

            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() =>
                {
                    dataGridView.DataSource = daftarDataPengajaran;
                }));
            }
            else
            {
                dataGridView.DataSource = daftarDataPengajaran;
            }
        }

        private void ButtonPilih_Click(object sender, EventArgs e) 
        { 
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                var mapelKelasPilihan = gemilangDbContext.TupleMataPelajaranKelas.Find(id);

                navigasiService.Navigasi(new PageIndexTopik(navigasiService, mapelKelasPilihan));
            }
            else MessageBox.Show("Pilih dulu data di datagridview", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}