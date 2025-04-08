using _12A1Cs2_2425Proj4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace _12A1Cs2_2425Proj4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the database context
            using(var context = new BookCatalogContext())
            {
                var book = context.Books
                    .Include("BookAuthors.Author")
                    .FirstOrDefault(b => b.Id == 74);

                var authors = book?.BookAuthors.Select(ba => ba.Author.Name).ToList();

            }
            Book book1 = new Book
            {
                Title = "Book Title",
                Rating = 4.5f,
                Edition = "1st Edition",
                Language = "English",
            };
            AddBook(book1);

            book1.Title = "WAZZAAAAAAAAAAAAAAAAAAAAP";
            UpdateBook(book1);

            DeleteBook(book1);
        }

        public void AddBook(Book newBook)
        {
            // Can't add authors or genres (ain't no way I'm gonna figure this shi out)
            using (var context = new BookCatalogContext())
            {
                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var context = new BookCatalogContext())
            {
                return context.Books
                              .Include("BookAuthors.Author")
                              //.Include("BookGenres.Genre")
                              .ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var context = new BookCatalogContext())
            {
                return context.Books
                              .Include("BookAuthors.Author")
                              //.Include("BookGenres.Genre")
                              .FirstOrDefault(b => b.Id == id);
            }
        }

        public void UpdateBook(Book book)
        {
            using (var context = new BookCatalogContext())
            {
                var existing = context.Books.Find(book.Id);
                if (existing != null)
                {
                    existing.Title = book.Title;
                    existing.Rating = book.Rating;
                    existing.Edition = book.Edition;
                    existing.Language = book.Language;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteBook(Book book)
        {
            using (var context = new BookCatalogContext())
            {
                var existing = context.Books.Find(book.Id);
                if (book != null)
                {
                    context.Books.Remove(existing);
                    context.SaveChanges();
                }
            }
        }



        //---------- events ----------  
        private void btn_Save_Click(object sender, RoutedEventArgs r)
        {
        }
        private void btn_Duplicate_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btn_SaveToFile_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}
