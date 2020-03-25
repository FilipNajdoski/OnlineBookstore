using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;

namespace OnlineBookstore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int categoryID)
        {
                Category category = GetCategoriesById(categoryID);
                _context.Categories.Remove(category);
                _context.SaveChanges();
        }

        public void Edit(Category category)
        {
                _context.Categories.Update(category);
                _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
                var result = _context.Categories.AsEnumerable();
                return result;
        }

        public Category GetCategoriesById(int id)
        {
                var result = _context.Categories.FirstOrDefault(x => x.Id == id);
                return result;
        }
    }
}
