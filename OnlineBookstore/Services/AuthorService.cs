using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;


        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public void Add(Author author)
        {
            _authorRepository.Add(author);
        }

        public void Delete(int authorID)
        {
            _authorRepository.Delete(authorID);
        }

        public void Edit(Author author)
        {
            _authorRepository.Edit(author);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var result = _authorRepository.GetAllAuthors();
            return result;
        }

        public Author GetAuthorById(int id)
        {
            var result = _authorRepository.GetAuthorById(id);
            return result;
        }
    }
}
