using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author}, ISBN: {ISBN}, Year: {PublishYear}";
        }
    }
}
