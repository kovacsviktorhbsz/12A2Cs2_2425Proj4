using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> GenreAuthors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // BookAuthor (issues with property to column mapping)
            modelBuilder.Entity<BookAuthor>()
                .Property(ba => ba.BookId)
                .HasColumnName("book_id");

            modelBuilder.Entity<BookAuthor>()
                .Property(ba => ba.AuthorId)
                .HasColumnName("author_id");

            // GenreAuthor (issues with property to column mapping)
            modelBuilder.Entity<BookGenre>()
                .Property(ba => ba.BookId)
                .HasColumnName("book_id");

            modelBuilder.Entity<BookGenre>()
                .Property(ba => ba.GenreId)
                .HasColumnName("genre_id");

            // Composite keys
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookGenre>()
                .HasKey(ba => new { ba.BookId, ba.GenreId });

            modelBuilder.Entity<BookAuthor>()
                .HasRequired(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasRequired(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            //genre 
            modelBuilder.Entity<BookGenre>()
                .HasRequired(ba => ba.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasRequired(ba => ba.Genre)
                .WithMany(a => a.BookGenres)
                .HasForeignKey(ba => ba.GenreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
