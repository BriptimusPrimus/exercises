using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestBookService
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        //[WebGet]
        [WebInvoke(Method = "GET", UriTemplate = "GetBooksList",
              ResponseFormat = WebMessageFormat.Xml, 
              RequestFormat = WebMessageFormat.Xml,
              BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Book> GetBooksList();

        [OperationContract]
        //[WebGet(UriTemplate = "Book/{id}")]
        [WebInvoke(Method = "GET", UriTemplate = "Book/{id}")]
        Book GetBookById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddBook/{name}")]
        void AddBook(string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateBook/{id}/{name}")]
        void UpdateBook(string id, string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteBook/{id}")]
        void DeleteBook(string id);
    }

}
