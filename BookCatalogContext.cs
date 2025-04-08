using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _12A1Cs2_2425Proj4.Models;

namespace _12A1Cs2_2425Proj4
{
    internal class BookCatalogContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
