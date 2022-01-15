using Microsoft.AspNetCore.Mvc;
using my_books.Data.Contracts;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsService _authorsService;
        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor(AuthorVM authorVM)
        {
            _authorsService.AddAuthor(authorVM);
            return Ok(authorVM);
        }

        [HttpGet("authors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authorsService.GetAll());
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorVM authorVM)
        {
            return Ok(_authorsService.UpdateAuthor(id, authorVM));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            return Ok(_authorsService.DeleteAuthor(id));
        }

        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_authorsService.GetAuthorWithBooksById(id));
        }

        [HttpGet("get-books-of-author/{authorId}")]
        public IActionResult GetBooksOfAuthor(int authorId)
        {
            return Ok(_authorsService.GetBooksOfAuthor(authorId));
        }
    }
}
