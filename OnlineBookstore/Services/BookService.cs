using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Logger;
using OnlineBookstore.Repositories.Repositories.Interfaces;

namespace OnlineBookstore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public  BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
            _logger.LogInformation(LoggerMessageDisplay.BookCreated);
        }

        public void Delete(int bookId)
        {
            _bookRepository.Delete(bookId);
        }

        public void Edit(Book book)
        {
            _bookRepository.Edit(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _bookRepository.GetAllBooks();
            return result;
        }

        public Book GetBookById(int id)
        {
            var result = _bookRepository.GetBookById(id);
            return result;
        }
    }
}
