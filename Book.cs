using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _12A1Cs2_2425Proj4
{
    [Table("book")]
    public  class Book
    {
        public Book() 
        {
            this.BookAuthors = new HashSet<BookAuthor>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public float Rating {  get; set; }
        public string Edition { get; set; }
        public string Language { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }  
    }
}
