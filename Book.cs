using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Publication_date { get; set; }
        public string ISBN { get; set; }
        public bool BookNotTaken { get; set; }
        public Book(string name, string author, string category, string language, string publication_date, string isbn)
        {
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            Publication_date = publication_date;
            ISBN = isbn;
        }
        public Book() { }
    }
}
