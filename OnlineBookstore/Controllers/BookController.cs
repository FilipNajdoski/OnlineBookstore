using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Logger;
using OnlineBookstore.Models;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using OnlineBookstore.Services;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Controllers
{
    [Authorize(Roles = "admin, editor")]
    public class BookController : Controller
    {
        
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookService bookService,
            ICategoryService categoryService,
            IAuthorService authorService,
            IPublisherService publisherService,
            ILogger<BookController> logger
            )
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
            _logger = logger;
        }
        // GET: Books
        public IActionResult Index()
        {
            var bookList = _bookService.GetAllBooks();
            if (bookList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.BooksListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoBookFound);
            }
            return View(bookList);
        }

        public JsonResult FillBooksDataTable()
        {
            var booklist = _bookService.GetAllBooks();
            return Json(new { data = booklist });
        }

        //GET: BOOK/CREATE
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var Categories = _categoryService.GetAllCategories();
            var Authors = _authorService.GetAllAuthors();
            var Publishers = _publisherService.GetAllPublishers();

            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Categories = GetSelectListItemsCategory(Categories);
            bookViewModel.Authors = GetSelectListItemsAuthors(Authors);
            bookViewModel.Publishers = GetSelectListItemsPublishers(Publishers);

            return View(bookViewModel);
        }

        private IEnumerable<SelectListItem> GetSelectListItemsPublishers(IEnumerable<Publisher> publishers)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select Publisher..."
            });
            foreach (var element in publishers)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListItemsAuthors(IEnumerable<Author> authors)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select Author..."
            });
            foreach (var element in authors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListItemsCategory(IEnumerable<Category> categories)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select Category..."
            });
            foreach (var element in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });              
            }
            return selectList;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            var book = new Book();

            if(ModelState.IsValid)
            {
                book.BookType = bookViewModel.BookType;
                book.CategoryID = bookViewModel.CategoryID;
                book.CategoryName = bookViewModel.CategoryName;
                book.Copies = bookViewModel.Copies;
                book.Country = bookViewModel.Country;
                book.Description = bookViewModel.Description;
                book.Dimensions = bookViewModel.Dimensions;
                book.Edition = bookViewModel.Edition;
                book.Genre = bookViewModel.Genre;
                book.Language = bookViewModel.Language;
                book.NumberOfPages = bookViewModel.NumberOfPages;
                book.Price = bookViewModel.Price;
                book.Shipping = bookViewModel.Shipping;
                book.Title = bookViewModel.Title;
                book.Weight = bookViewModel.Weight;
                book.YearOfIssue = bookViewModel.YearOfIssue;
                //book.UserId = bookViewModel.UserId;
                book.PublisherID = bookViewModel.PublisherID;
                book.PublisherName = bookViewModel.PublisherName;
                book.AuthorID = bookViewModel.AuthorID;
                book.AuthorName = bookViewModel.AuthorName;
                book.PhotoURL = bookViewModel.PhotoURL;

                _bookService.Add(book);
                return RedirectToAction(nameof(Index));
            }
            
           return View();
        }
        [Authorize(Roles = "admin, editor")]
        //GET: BOOK/EDIT
        public IActionResult Edit(int Id)
        {
            var book = _bookService.GetBookById(Id);
            if(book == null) 
            { 
                return NotFound(); 
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.Edit(book);
                }
                catch (Exception ex)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        [Authorize(Roles = "admin, editor")]
        public IActionResult Details (int Id)
        {
            var book = _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int Id)
        {
            var book = _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _bookService.Delete(Id); 
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin, editor")]
        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                    var dbPath = fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    { 
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}