using AutoMapper;
using my_books.Data.Contracts;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace my_books.Data.Services
{
    public class PublishersService : IPublishersService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private IResponseModel _responseModel;
        public PublishersService(AppDbContext context, IMapper mapper, IResponseModel responseModel)
        {
            _mapper = mapper;
            _context = context;
            _responseModel = responseModel;
        }

        public object AddPublisher(PublisherVM publisherVM)
        {
            var publisherBeingAdded = _mapper.Map<Publisher>(publisherVM);
            _context.Publishers.Add(publisherBeingAdded);
            if (_context.SaveChanges() > 0)
            {
                _responseModel.HttpStatusCode = HttpStatusCode.Created;
                _responseModel.DataObject = publisherBeingAdded;
                _responseModel.Message = "Publisher has been added successfully!";
            }

            return _responseModel;
        }

        public object DeletePublisher(int publisherId)
        {
            var publisherBeingDeleted = _context.Publishers.FirstOrDefault(b => b.ID == publisherId);
            if (publisherBeingDeleted != null)
            {
                _context.Publishers.Remove(publisherBeingDeleted);
                if (_context.SaveChanges() > 0)
                {
                    _responseModel.HttpStatusCode = HttpStatusCode.OK;
                    _responseModel.Message = $"Publisher with ID {publisherId} has been deleted successfully!";
                }
            }

            return _responseModel;
        }

        public object GetAll()
        {
            return _context.Publishers.ToList();
        }

        public object GetPublisherById(int id)
        {
            var publisherById = _context.Publishers.FirstOrDefault(publisher => publisher.ID == id);
            _responseModel.HttpStatusCode = publisherById != null ? HttpStatusCode.Found : HttpStatusCode.NotFound;
            _responseModel.DataObject = publisherById;
            return _responseModel;
        }

        public object GetPublisherWithBooksAndAuthor(int id)
        {
            return _context.Publishers.Where(n => n.ID == id)
                .Select(n => new PublisherVM()
                {
                    Name = n.Name,
                    BooksAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BooksAuthors = n.Author_Books.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
        }


        public bool UpdatePublisher(int publisherId, PublisherVM publisherVM)
        {
            bool isPublisherUpdated = false;
            var publisherBeingUpdated = _context.Publishers.FirstOrDefault(p => p.ID == publisherId);
            if (publisherBeingUpdated != null)
            {
                publisherBeingUpdated.Name = publisherVM.Name;
                if (_context.SaveChanges() > 0)
                {
                    isPublisherUpdated = true;
                }
            }
            return isPublisherUpdated;
        }
    }
}
