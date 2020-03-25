using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Repositories.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        void Add(Book book);
        void Edit(Book book);
        void Delete(int bookId);
        Book GetBookById(int id);
    }
}
