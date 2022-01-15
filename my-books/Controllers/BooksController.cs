using Microsoft.AspNetCore.Mvc;
using my_books.Data.Contracts;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook(BookVM bookVM)
        {
            _booksService.AddBookWithAuthor(bookVM);
            return Ok(bookVM);
        }

        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            return Ok(_booksService.GetAll());
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookVM bookVM)
        {
            return Ok(_booksService.UpdateBook(id, bookVM));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            return Ok(_booksService.DeleteBook(id));
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var bookWithAuthors = _booksService.GetBookById(id);
            return Ok(bookWithAuthors);
        }

        [HttpGet("get-book-with-publisher-author/{id}")]
        public IActionResult GetBookWithPublisherAndAuthor(int id)
        {
            var bookWithAuthors = _booksService.GetBookWithPublisherAndAuthor(id);
            return Ok(bookWithAuthors);
        }

        [HttpGet]
        [Route("get-authors-of-book/{bookId}")]
        public IActionResult GetAuthorsOfBook(int bookId)
        {
            var authorsOfBook = _booksService.GetAuthorsOfBook(bookId);
            return Ok(authorsOfBook);
        }
    }
}
