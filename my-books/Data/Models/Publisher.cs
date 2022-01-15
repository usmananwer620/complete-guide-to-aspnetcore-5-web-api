using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
