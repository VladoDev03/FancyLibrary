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
        public IActionResult Authors()
        {
            List<Author> authors = authorServices.GetAllAuthors();

            List<AuthorDTO> result = new List<AuthorDTO>();

            foreach (var item in authors)
            {
                AuthorDTO author = new AuthorDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    BooksCount = authorServices.GetAuthorBooksCount(item)
                };

                result.Add(author);
            }

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
    }
}
