using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12A1Cs2_2425Proj4.Models
{
    [Table("author")]
    internal class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role {  get; set; }
    }
}
