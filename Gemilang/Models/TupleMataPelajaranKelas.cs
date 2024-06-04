using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class TupleMataPelajaranKelas
    {
        public int Id { get; set; }
        public int IdMataPelajaran { get; set; }
        public int IdKelas { get; set; }


        public MataPelajaran MataPelajaran { get; set; }
        public Kelas Kelas { get; set; }

        public ICollection<DataPengajaran> ListDataPengajaran {  get; set; }
        public ICollection<Topik> ListTopik { get; set; }

        public string DisplayTuple => $"{MataPelajaran.Nama} | {Kelas.Nama}";
    }
}
