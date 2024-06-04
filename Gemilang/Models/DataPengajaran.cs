using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class DataPengajaran
    {
        public int IdGuru { get; set; }
        public int IdTupleMataPelajaranKelas { get; set; }


        public Guru Guru { get; set; }
        public TupleMataPelajaranKelas TupleMataPelajaranKelas { get; set; }
    }
}
