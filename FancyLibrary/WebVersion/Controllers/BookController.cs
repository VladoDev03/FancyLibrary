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
using Data.ViewModels;

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

        [Route("/Book/Books/{strategy?}")]
        public IActionResult Books(string strategy = "title")
        {
            List<Book> books = bookServices.GetAllBooks();
            List<BookView> booksViews = new List<BookView>();

            foreach (Book item in books)
            {
                Author author = authorServices.FindAuthor(item.AuthorId);

                string authorName = NameRefactorer
                    .GetFullName(author.FirstName, author.MiddleName, author.LastName);

                BookView book = new BookView
                {
                    Id = item.Id,
                    Title = item.Title,
                    Genre = item.Genre,
                    AuthorName = authorName,
                    Year = item.Year,
                    SavedTimes = bookServices.GetBookSavedTimes(item)
                };

                booksViews.Add(book);
            }

            booksViews = OrderByStrategy(booksViews, strategy);

            return View(booksViews);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDTO book)
        {
            if (ValidateProperties(book))
            {
                return View();
            }

            if (bookServices.FindBook(book.Title) != null)
            {
                ViewData.Add("RepeatingTitle", "Book already exists!");

                return View();
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

        private bool ValidateProperties(BookDTO book)
        {
            if (book.Title == null)
            {
                ViewData.Add("TitleError", "Title is required!");

                return true;
            }
            else if (book.Genre == null)
            {
                ViewData.Add("GenreError", "Genre is required!");

                return true;
            }
            else if (book.FirstName == null)
            {
                ViewData.Add("AuthorFirstNameError", "Author first name is required!");

                return true;
            }
            else if (book.LastName == null)
            {
                ViewData.Add("AuthorLastNameError", "Author last name is required!");

                return true;
            }

            return false;
        }

        [HttpPost]
        [ActionName("Details")]
        public IActionResult DetailsTitle(string title)
        {
            if (title == null)
            {
                return RedirectToAction(nameof(Books));
            }

            Book book = bookServices.FindBook(title);

            FullBookView result = GetDetails(book);

            if (result == null)
            {
                return RedirectToAction(nameof(Books));
            }

            return View(result);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException();
            }

            Book book = bookServices.FindBook(id);

            FullBookView result = GetDetails(book);

            if (result == null)
            {
                return RedirectToAction(nameof(Books));
            }

            return View(result);
        }

        private FullBookView GetDetails(Book book)
        {
            if (book == null)
            {
                return null;
            }

            Author author = authorServices.FindAuthor(book.AuthorId);
            string authorFullName = NameRefactorer
                .GetFullName(author.FirstName, author.MiddleName, author.LastName);

            FullBookView result = new FullBookView
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                AuthorName = authorFullName,
                Year = book.Year,
                Pages = book.Pages,
                SavedTimes = bookServices.GetBookSavedTimes(book)
            };

            return result;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Books));
            }

            Book book = bookServices.FindBook(id);

            EditBookDTO result = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Year = book.Year,
                Pages = book.Pages
            };

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(EditBookDTO newData)
        {
            Book book = bookServices.FindBook(newData.Title);

            if (book != null)
            {
                ViewData.Add("TitleRepeatingError", "A book with this title already exists!");
                return View(newData);
            }

            try
            {
                bookServices.UpdateBook(newData);
            }
            catch (ArgumentException ae)
            {
                ViewData.Add("ShortTitle", ae.Message);
                return View(newData);
            }

            bookServices.UpdateBook(newData);

            return RedirectToAction(nameof(Books));
        }

        private List<BookView> OrderByStrategy(List<BookView> books, string strategy)
        {
            if (strategy == "title")
            {
                return books.OrderBy(b => b.Title).ToList();
            }
            else if (strategy == "genre")
            {
                return books.OrderBy(b => b.Genre).ToList();
            }
            else if (strategy == "author")
            {
                return books.OrderBy(b => b.AuthorName).ToList();
            }
            else if (strategy == "saved")
            {
                return books.OrderByDescending(b => b.SavedTimes).ToList();
            }
            else
            {
                return books;
            }
        }
    }
}
