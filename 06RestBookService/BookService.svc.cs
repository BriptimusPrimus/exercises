using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using AutoLotDAL;

namespace RestBookService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        public List<Book> GetBooksList()
        {
            List<Book> books = new List<Book>();
            using (AutoLotEntities entities = new AutoLotEntities())
            { 
                foreach (var c in entities.Customers)
                {
                    books.Add(new Book
                    {
                        Id = c.CustID,
                        BookName = c.FirstName
                    });
                }
            }
            return books;
        }

        public Book GetBookById(string id)
        {
            try
            {
                int bookId = Convert.ToInt32(id);

                using (AutoLotEntities entities = new AutoLotEntities())
                {
                    var cust = entities.Customers.SingleOrDefault(c => c.CustID == bookId);
                    return new Book { Id = cust.CustID, BookName = cust.FirstName };
                }                
            }
            catch (Exception ex)
            {
                throw new FaultException(String.Format("Something went wrong: {0}", ex.Message));
            }
        }

        public void AddBook(string name)
        {
            using (AutoLotEntities entities = new AutoLotEntities())
            {
                Customer book = new Customer { FirstName = name };
                entities.Customers.Add(book);
                entities.SaveChanges();
            }
        }

        public void UpdateBook(string id, string name)
        {
            try
            {
                int bookId = Convert.ToInt32(id);

                using (AutoLotEntities entities = new AutoLotEntities())
                {
                    //Customer book = entities.Customers.SingleOrDefault(c => c.CustID == bookId);
                    Customer book = entities.Customers.Find(bookId);
                    if (book == null)
                    {
                        return;
                    }
                    book.FirstName = name;
                    entities.SaveChanges();
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        public void DeleteBook(string id)
        {
            try
            {
                int bookId = Convert.ToInt32(id);

                using (AutoLotEntities entities = new AutoLotEntities())
                {
                    //Customer book = entities.Customers.SingleOrDefault(c => c.CustID == bookId);
                    Customer book = entities.Customers.Find(bookId);
                    entities.Customers.Remove(book);
                    entities.SaveChanges();
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }
    }
}
