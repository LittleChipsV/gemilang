using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class MataPelajaran
    {
        public int Id { get; set; }
        public required string Nama { get; set; }

        public ICollection<Topik>? ListTopik { get; set; }
        public ICollection<TupleMataPelajaranKelas> ListTupleMataPelajaranKelas {  get; set; }
    }
}
