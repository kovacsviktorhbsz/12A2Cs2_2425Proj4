using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12A1Cs2_2425Proj4
{
    [Table("author")]
    public class Author
    {
        public Author() 
        {
            this.BookAuthors = new HashSet<BookAuthor>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role {  get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
