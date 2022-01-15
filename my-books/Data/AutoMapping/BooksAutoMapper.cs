using AutoMapper;
using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.AutoMapping
{
    public class BooksAutoMapper : Profile
    {
        public BooksAutoMapper()
        {
            CreateMap<Book, BookVM>().ReverseMap();
            CreateMap<Book, BookWithAuthorVM>().ReverseMap();
            CreateMap<Publisher, PublisherVM>().ReverseMap();
            CreateMap<Author, AuthorVM>().ReverseMap();
        }
    }
}
