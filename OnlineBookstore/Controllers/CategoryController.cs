using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categoryList = _categoryService.GetAllCategories();
            return View(categoryList);
        }
        //GET: Category/CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [HttpPost]
        public JsonResult CreateCategoryAjax(string name)
        {
            var category = new Category();
            if (name != "" || name != null)
            {
                category.Name = name;
                _categoryService.Add(category);
            }
            return Json(category);
        }
        //GET: BOOK/EDIT
        public IActionResult Edit(int Id)
        {
            var category = _categoryService.GetCategoriesById(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Edit(category);
                }
                catch (Exception ex)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Details(int Id)
        {
            var category = _categoryService.GetCategoriesById(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public IActionResult Delete(int Id)
        {
            var category = _categoryService.GetCategoriesById(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Delete(Id);
            }

            return RedirectToAction(nameof(Index));
        }
        
    }
}