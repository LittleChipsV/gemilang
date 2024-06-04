using Gemilang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gemilang.Views.Pages.Nilai
{
    public partial class Statistik : Form
    {
        private Models.TupleMataPelajaranKelas mapelKelas;
        private Models.Siswa siswa;
        private GemilangDbContext dbContext;

        public Statistik(Models.TupleMataPelajaranKelas mapelKelas, Models.Siswa siswa)
        {
            InitializeComponent();
            this.mapelKelas = mapelKelas;
            this.siswa = siswa;
            dbContext = new GemilangDbContext();

            labelMataPelajaran.Text = mapelKelas.MataPelajaran.Nama;
            labelKelas.Text = mapelKelas.Kelas.Nama;

            HitungStatistik();
        }

        private void HitungStatistik()
        {
            var nilai = dbContext.NilaiSiswa
                .Where(ns => ns.IdSiswa == siswa.Id && ns.Topik.IdTupleMataPelajaranKelas == mapelKelas.Id)
                .Select(ns => (int)ns.Nilai)
                .ToList();

            if (nilai.Any())
            {
                double rataRata = nilai.Average();
                double median = HitungMedian(nilai);
                double standarDeviasi = HitungStandarDeviasi(nilai);
                int min = nilai.Min();
                int max = nilai.Max();

                textBoxRataRata.Text = rataRata.ToString();
                textBoxNilaiTengah.Text = median.ToString();
                textBoxStandarDeviasi.Text = standarDeviasi.ToString();

                textBoxTertinggi.Text = max.ToString();
                textBoxTerendah.Text = min.ToString();
            }
            else
            {
                MessageBox.Show("Tidak ada data", "Pesan");
            }
        }

        private double HitungMedian(List<int> nilai)
        {
            nilai.Sort();
            double median;
            if (nilai.Count % 2 == 0)
            {
                median = (nilai[nilai.Count / 2 - 1] + nilai[nilai.Count / 2]) / 2.0;
            }
            else
            {
                median = nilai[nilai.Count / 2];
            }
            return median;
        }

        private double HitungStandarDeviasi(List<int> nilai)
        {
            double rataRata = nilai.Average();
            double standarDeviasi = Math.Sqrt(nilai.Select(g => Math.Pow(g - rataRata, 2)).Sum() / nilai.Count);
            return standarDeviasi;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
