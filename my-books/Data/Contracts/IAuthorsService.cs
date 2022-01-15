using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Collections.Generic;

namespace my_books.Data.Contracts
{
    public interface IAuthorsService
    {
        List<Author> GetAll();
        object GetAuthorWithBooksById(int id);
        object GetBooksOfAuthor(int authorId);
        bool AddAuthor(AuthorVM authorVM);
        bool UpdateAuthor(int authorId, AuthorVM authorVM);
        bool DeleteAuthor(int authorId);
    }
}
