using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Repositories.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        void Add(Author author);
        void Edit(Author author);
        void Delete(int authorID);
        Author GetAuthorById(int id);
    }
}
