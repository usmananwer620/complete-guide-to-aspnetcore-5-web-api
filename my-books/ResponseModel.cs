using my_books.Data.Contracts;
using System.Net;

namespace my_books
{
    public class ResponseModel : IResponseModel
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public object DataObject { get; set; }
    }
}
