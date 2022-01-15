using System.Net;

namespace my_books.Data.Contracts
{
    public interface IResponseModel
    {
        string Message { get; set; }
        HttpStatusCode HttpStatusCode { get; set; }
        object DataObject { get; set; }
    }
}
