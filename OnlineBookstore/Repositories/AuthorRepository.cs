using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;

namespace OnlineBookstore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int authorID)
        {
            Author author = GetAuthorById(authorID);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void Edit(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var result = _context.Authors.AsEnumerable();
            return result;
        }

        public Author GetAuthorById(int id)
        {
            var result = _context.Authors.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
