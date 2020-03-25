using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Repositories.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        void Add(Category category);
        void Edit(Category category);
        void Delete(int categoryID);
        Category GetCategoriesById(int id);
    }
}
