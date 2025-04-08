using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12A1Cs2_2425Proj4.Models
{
    [Table("genre")]
    internal class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
