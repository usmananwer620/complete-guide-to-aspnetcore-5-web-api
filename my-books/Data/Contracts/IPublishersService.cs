using my_books.Data.ViewModels;
using System.Collections.Generic;

namespace my_books.Data.Contracts
{
    public interface IPublishersService
    {
        object GetAll();
        object GetPublisherById(int id);
        object GetPublisherWithBooksAndAuthor(int id);
        object AddPublisher(PublisherVM publisherVM);
        bool UpdatePublisher(int publisherId, PublisherVM publisherVM);
        object DeletePublisher(int publisherId);
    }
}
