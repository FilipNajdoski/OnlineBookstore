using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Services.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        void Add(Author author);
        void Edit(Author author);
        void Delete(int authorID);
        Author GetAuthorById(int id);
    }
}
