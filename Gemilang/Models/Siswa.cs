using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class Siswa : User
    {
        public int IdKelas { get; set; }


        public Kelas? Kelas { get; set; }
        public ICollection<NilaiSiswa>? ListNilaiSiswa { get; set; }
    }
}
