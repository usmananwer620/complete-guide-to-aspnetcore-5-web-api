using AutoMapper;
using my_books.Data.Contracts;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorsService : IAuthorsService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public AuthorsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddAuthor(AuthorVM authorVM)
        {
            bool isAuthorAdded = false;
            var authorBeingAdded = _mapper.Map<Author>(authorVM);
            _context.Authors.Add(authorBeingAdded);
            if (_context.SaveChanges() > 0)
                isAuthorAdded = true;

            return isAuthorAdded;
        }

        public bool DeleteAuthor(int authorId)
        {
            bool isAuthorDeleted = false;
            var authorBeingDeleted = _context.Authors.FirstOrDefault(b => b.Id == authorId);
            if (authorBeingDeleted != null)
            {
                _context.Authors.Remove(authorBeingDeleted);
                if (_context.SaveChanges() > 0)
                    isAuthorDeleted = true;
            }

            return isAuthorDeleted;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public object GetAuthorWithBooksById(int id)
        {
            return _context.Authors.Where(author => author.Id == id).Select(a => new BooksOfAnAuthor()
            {
                FullName = a.FullName,
                BookNames = a.Author_Books.Select(ab => ab.Book.Title).ToList()
            }).FirstOrDefault();
        }

        public object GetBooksOfAuthor(int authorId)
        {
            return _context.Authors.Where(author => author.Id == authorId).Select(a => new BooksOfAnAuthor()
            {
                FullName = a.FullName,
                BookNames = a.Author_Books.Select(ab => ab.Book.Title).ToList()
            }).FirstOrDefault();
        }

        public bool UpdateAuthor(int authorId, AuthorVM authorVM)
        {
            bool isAuthorUpdated = false;
            var authorBeingUpdated = _context.Authors.FirstOrDefault(b => b.Id == authorId);
            if (authorBeingUpdated != null)
            {
                authorBeingUpdated.FullName = authorVM.FullName;
                if (_context.SaveChanges() > 0)
                {
                    isAuthorUpdated = true;
                }
            }
            return isAuthorUpdated;
        }
    }
}
