using Data.Entities;
using Data.Models;
using Data.Utils;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVersion.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorServices authorServices;

        public AuthorController(IAuthorServices authorServices)
        {
            this.authorServices = authorServices;
        }

        [HttpGet]
        [Route("/Author/Authors/{strategy?}")]
        public IActionResult Authors(string strategy = "fullName")
        {
            List<Author> authors = authorServices.GetAllAuthors();

            List<AuthorView> result = new List<AuthorView>();

            foreach (var item in authors)
            {
                AuthorView author = new AuthorView
                {
                    Id = item.Id,
                    FullName = NameRefactorer.GetFullName(item.FirstName, item.MiddleName, item.LastName),
                    BooksCount = authorServices.GetAuthorBooksCount(item),
                    Country = authorServices.GetAuthorCountry(item)
                };

                result.Add(author);
            }

            result = OrderByStrategy(result, strategy);

            return View(result);
        }

        [HttpPost]
        public IActionResult Create(AuthorDTO authorInput)
        {
            if (authorInput.FirstName == null || authorInput.LastName == null)
            {
                return RedirectToAction(nameof(Authors));
            }

            string name = NameRefactorer
                .GetFullName(authorInput.FirstName, authorInput.MiddleName, authorInput.LastName);

            Author author = authorServices.FindAuthor(name);

            if (author != null)
            {
                return RedirectToAction(nameof(Authors));
            }

            Author authorToAdd = new Author
            {
                FirstName = authorInput.FirstName,
                MiddleName = authorInput.MiddleName,
                LastName = authorInput.LastName
            };

            if (authorServices.FindAuthor(name) == null)
            {
                authorServices.AddAuthor(authorToAdd);
            }

            return RedirectToAction(nameof(Authors));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Authors));
            }

            Author author = authorServices.FindAuthor(id);

            FullAuthorView result = GetDetails(author);

            if (result == null)
            {
                return RedirectToAction(nameof(Authors));
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult Details(string name)
        {
            if (name == null)
            {
                return RedirectToAction(nameof(Authors));
            }

            Author author = authorServices.FindAuthor(name);

            FullAuthorView result = GetDetails(author);

            if (result == null)
            {
                return RedirectToAction(nameof(Authors));
            }

            return View(result);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        private FullAuthorView GetDetails(Author author)
        {
            if (author == null)
            {
                return null;
            }

            string name = NameRefactorer.GetFullName(author.FirstName, author.MiddleName, author.LastName);

            string countryName = authorServices.GetAuthorCountry(author);
            string birthday = author.Birthday.ToString() != "" ? author.Birthday.ToString() : "Unknown";

            FullAuthorView result = new FullAuthorView
            {
                Id = author.Id,
                Name = name,
                BookCount = authorServices.GetAuthorBooksCount(author),
                Birthday = birthday,
                Nickname = author.Nickname != null ? author.Nickname : "Unknown",
                Country = countryName
            };

            return result;
        }

        public List<AuthorView> OrderByStrategy(List<AuthorView> authors, string strategy)
        {
            if (strategy == "fullName")
            {
                return authors.OrderBy(a => a.FullName).ToList();
            }
            else if (strategy == "booksCount")
            {
                return authors.OrderBy(a => a.BooksCount).ToList();
            }
            else if (strategy == "country")
            {
                List<AuthorView> temps = authors.Where(a => a.Country == "Unknown").ToList();

                authors = authors
                    .Where(a => a.Country != "Unknown")
                    .OrderBy(a => a.Country)
                    .ToList();

                authors.AddRange(temps);

                return authors;
            }
            else
            {
                return authors;
            }
        }
    }
}
