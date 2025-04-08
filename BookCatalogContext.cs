using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _12A1Cs2_2425Proj4.Models;
using System.Windows.Input;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _12A1Cs2_2425Proj4
{
    internal class BookCatalogContext : DbContext
    {
        public BookCatalogContext() : base("name=BookCatalogContext")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Composite keys
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.book_id, ba.author_id });

            modelBuilder.Entity<BookAuthor>()
                .HasRequired(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.book_id);

            modelBuilder.Entity<BookAuthor>()
                .HasRequired(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.author_id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
