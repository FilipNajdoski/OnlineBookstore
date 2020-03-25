using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public IActionResult Index()
        {
            var publisherList = _publisherService.GetAllPublishers();
            return View(publisherList);
        }
        //GET: Category/CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publisherService.Add(publisher);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [HttpPost]
        public JsonResult CreatePublisherAjax(string name, string country)
        {
            var publisher = new Publisher();
            if (name != "" || name != null && country != "" || country != null)
            {
                publisher.Name = name;
                publisher.Country = country;
                _publisherService.Add(publisher);
            }
            return Json(publisher);
        }
        //GET: BOOK/EDIT
        public IActionResult Edit(int Id)
        {
            var publisher = _publisherService.GetPublishersById(Id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _publisherService.Edit(publisher);
                }
                catch (Exception ex)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }
        public IActionResult Details(int Id)
        {
            var publisher = _publisherService.GetPublishersById(Id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        public IActionResult Delete(int Id)
        {
            var publisher = _publisherService.GetPublishersById(Id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _publisherService.Delete(Id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}