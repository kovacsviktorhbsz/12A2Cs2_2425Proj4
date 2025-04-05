using _12A1Cs2_2425Proj4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace _12A1Cs2_2425Proj4
{
    internal class DatabaseHandler
    {
        public List<Book> Records { get; set; }
        public Book CurrentlySelected { get; set; }

        public DatabaseHandler()
        {
            Records = new List<Book>();
        }
    }
}
