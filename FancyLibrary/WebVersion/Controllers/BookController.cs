using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVersion.Controllers
{
    public class BookController : Controller
    {
        private IBookServices services;

        public BookController(IBookServices services)
        {
            this.services = services;
        }

        public IActionResult Books()
        {
            List<Book> books = services.GetAllBooks();
            return View(books);
        }
    }
}
