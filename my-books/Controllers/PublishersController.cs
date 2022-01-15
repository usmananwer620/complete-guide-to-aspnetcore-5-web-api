using Microsoft.AspNetCore.Mvc;
using my_books.Data.Contracts;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private IPublishersService _publishersService;
        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher(PublisherVM publisherVM)
        {
            var addedPublisherResponse = _publishersService.AddPublisher(publisherVM);
            return Ok(addedPublisherResponse);
        }

        [HttpGet("publishers")]
        public IActionResult GetAllPublishers()
        {
            return Ok(_publishersService.GetAll());
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePublisher(int id, [FromBody] PublisherVM publisherVM)
        {
            return Ok(_publishersService.UpdatePublisher(id, publisherVM));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            return Ok(_publishersService.DeletePublisher(id));
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            return Ok(_publishersService.GetPublisherById(id));
        }

        [HttpGet("get-publisher-with-books-and-author/{id}")]
        public IActionResult GetPublisherWithBooksAndAuthor(int id)
        {
            var publisherWithBooksAndAuthor = _publishersService.GetPublisherWithBooksAndAuthor(id);
            return Ok(publisherWithBooksAndAuthor);
        }
    }
}
