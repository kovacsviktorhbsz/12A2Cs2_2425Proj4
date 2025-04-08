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
                MessageBox.Show(String.Join("\n", authors));
            }
            return;
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
