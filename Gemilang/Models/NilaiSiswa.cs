using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class NilaiSiswa
    {
        public int Id { get; set; }
        public required byte Nilai { get; set; }
        public required int IdSiswa {  get; set; }
        public required int IdTopik { get; set; }


        public Siswa Siswa { get; set; }
        public Topik Topik { get; set; }
    }
}
