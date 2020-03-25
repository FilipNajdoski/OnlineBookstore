using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;


        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Delete(int categoryID)
        {
            _categoryRepository.Delete(categoryID);
        }

        public void Edit(Category category)
        {
            _categoryRepository.Edit(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var result = _categoryRepository.GetAllCategories();
            return result;
        }

        public Category GetCategoriesById(int id)
        {
            var result = _categoryRepository.GetCategoriesById(id);
            return result;
        }
    }
}
