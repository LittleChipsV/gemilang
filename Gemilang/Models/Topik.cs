using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class Topik
    {
        public int Id { get; set; }
        public required string Nama { get; set; }
        public required int IdTupleMataPelajaranKelas {  get; set; }


        public TupleMataPelajaranKelas TupleMataPelajaranKelas { get; set; }
        public ICollection<NilaiSiswa> ListNilaiSiswa { get; set; }
    }
}
