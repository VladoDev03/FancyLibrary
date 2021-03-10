using Data.Entities;
using Data.Models;
using Data.Utils;
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
        private IBookServices bookServices;
        private IAuthorServices authorServices;

        public BookController(IBookServices bookServices, IAuthorServices authorServices)
        {
            this.bookServices = bookServices;
            this.authorServices = authorServices;
        }

        public IActionResult Books()
        {
            List<Book> books = bookServices.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDTO book)
        {
            if (bookServices.FindBook(book.Title) != null)
            {
                return RedirectToAction(nameof(Create));
            }

            string fullName = NameRefactorer
                .GetFullName(book.FirstName, null, book.LastName);

            Author author = authorServices.FindAuthor(fullName);

            if (author == null)
            {
                author = new Author
                {
                    FirstName = book.FirstName,
                    LastName = book.LastName
                };

                authorServices.AddAuthor(author);
            }

            Book bookToAdd = new Book
            {
                Title = book.Title,
                Genre = book.Genre,
                AuthorId = author.Id
            };

            bookServices.AddBook(bookToAdd);

            return RedirectToAction(nameof(Books));
        }
    }
}
