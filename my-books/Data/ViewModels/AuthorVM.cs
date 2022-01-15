using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class BooksOfAnAuthor
    {
        public string FullName { get; set; }
        public List<string> BookNames { get; set; }
    }
}
