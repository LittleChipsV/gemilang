using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class Kelas
    {
        public int Id { get; set; }
        public required string Nama { get; set; }

        public ICollection<Siswa>? ListSiswa { get; set; }
        public ICollection<TupleMataPelajaranKelas> ListTupleMataPelajaranKelas { get; set; }
    }
}
