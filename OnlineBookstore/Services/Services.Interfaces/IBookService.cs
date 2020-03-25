using System.Collections.Generic;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void Add(Book book);
        void Edit(Book book);
        void Delete(int bookId);
        Book GetBookById(int id);
    }
}