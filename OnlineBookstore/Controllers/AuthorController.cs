using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            var authorList = _authorService.GetAllAuthors();
            return View(authorList);
            
        }
        //GET: Category/CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Add(author);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [HttpPost]
        public JsonResult CreateAuthorAjax(string name, string shortDescription)
        {
            var author = new Author();
            if (name != "" || name != null && shortDescription != "" || shortDescription != null)
            {
                author.Name = name;
                author.ShortDescription = shortDescription;
                _authorService.Add(author);
            }
            return Json(author);
        }
        //GET: BOOK/EDIT
        public IActionResult Edit(int Id)
        {
            var author = _authorService.GetAuthorById(Id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.Edit(author);
                }
                catch (Exception ex)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        public IActionResult Details(int Id)
        {
            var author = _authorService.GetAuthorById(Id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        public IActionResult Delete(int Id)
        {
            var author = _authorService.GetAuthorById(Id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _authorService.Delete(Id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}