using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace my_books.Data.Contracts
{
    public interface IBooksService
    {
        List<Book> GetAll();
        object GetBookById(int id);
        object GetAuthorsOfBook(int bookId);
        object GetBookWithPublisherAndAuthor(int id);
        bool AddBookWithAuthor(BookVM bookVM);
        bool UpdateBook(int bookId, BookVM bookVM);
        bool DeleteBook(int bookId);
    }
}
