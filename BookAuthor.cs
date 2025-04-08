using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12A1Cs2_2425Proj4
{
    [Table("book_author")]
    internal class BookAuthor
    {
        public int book_id { get; set; }
        public int author_id { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
