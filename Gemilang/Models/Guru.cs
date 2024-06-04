using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Models
{
    public class Guru : User
    {
        public ICollection<DataPengajaran> ListDataPengajaran { get; set; }
    }
}
