using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Services.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void Add(Category category);
        void Edit(Category category);
        void Delete(int categoryID);
        Category GetCategoriesById(int id);
    }
}
