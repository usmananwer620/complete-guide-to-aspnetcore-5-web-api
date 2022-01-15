using AutoMapper;
using my_books.Data.Contracts;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksService : IBooksService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public BooksService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public bool AddBookWithAuthor(BookVM bookVM)
        {
            bool isBookAdded = false;
            var bookBeingAdded = _mapper.Map<Book>(bookVM);
            bookBeingAdded.DateAdded = System.DateTime.Now;
            var _book_Authors = new List<Author_Book>();
            _context.Books.Add(bookBeingAdded);
            if (_context.SaveChanges() > 0)
                isBookAdded = true;
            foreach (var authorId in bookVM.AuthorIDs)
            {
                _book_Authors.Add(new Author_Book()
                {
                    AuthorId = authorId,
                    BookId = bookBeingAdded.ID
                });
            }
            _context.Author_Books.AddRange(_book_Authors);
            if (isBookAdded==true && _context.SaveChanges() > 0)
                isBookAdded = true;
            else
                isBookAdded = false;
            return isBookAdded;
        }

        public bool DeleteBook(int bookId)
        {
            bool isBookDeleted = false;
            var bookBeingDeleted = _context.Books.FirstOrDefault(b => b.ID == bookId);
            if (bookBeingDeleted != null)
            {
                _context.Books.Remove(bookBeingDeleted);
                if (_context.SaveChanges() > 0)
                    isBookDeleted = true;
            }

            return isBookDeleted;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public object GetBookById(int id)
        {
            return _context.Books.Where(book => book.ID == id).FirstOrDefault();
        }

        public object GetBookWithPublisherAndAuthor(int id)
        {
            return _context.Books.Where(book => book.ID == id).Select(b => new BookWithAuthorVM()
            {
                AuthorNames = b.Author_Books.Select(a => a.Author.FullName).ToList(),
                CoverURL = b.CoverURL,
                DateRead = b.DateRead,
                Description = b.Description,
                Genre = b.Genre,
                IsRead = b.IsRead,
                PublisherName = b.Publisher.Name,
                Rate = b.Rate,
                Title = b.Title
            }).FirstOrDefault();
        }

        public object GetAuthorsOfBook(int bookId)
        {
            return _context.Books.Where(book => book.ID == bookId).Select(b => new BookAuthorsVM()
            {
                Title = b.Title,
                AuthorNames = b.Author_Books.Select(a => a.Author.FullName).ToList(),
            }).FirstOrDefault();
        }

        public bool UpdateBook(int bookId, BookVM bookVM)
        {
            bool isBookUpdated = false;
            var bookBeingUpdated = _context.Books.FirstOrDefault(b => b.ID == bookId);
            if (bookBeingUpdated != null)
            {
                bookBeingUpdated.Title = bookVM.Title;
                bookBeingUpdated.Description = bookVM.Description;
                bookBeingUpdated.IsRead = bookVM.IsRead;
                bookBeingUpdated.Genre = bookVM.Genre;
                bookBeingUpdated.DateRead = bookVM.DateRead;
                bookBeingUpdated.Rate = bookVM.Rate;
                bookBeingUpdated.CoverURL = bookVM.CoverURL;
                bookBeingUpdated.PublisherID = bookVM.PublisherId;
                if (_context.SaveChanges() > 0)
                {
                    isBookUpdated = true;
                }
            }
            return isBookUpdated;
        }
    }
}
