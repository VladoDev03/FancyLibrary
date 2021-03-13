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
        private IAuthorServices services;

        public AuthorController(IAuthorServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public IActionResult Authors()
        {
            List<Author> authors = services.GetAllAuthors();
            return View(authors);
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

            Author author = services.FindAuthor(name);

            if (author != null)
            {
                return RedirectToAction(nameof(Authors));
            }

            Author authorToAdd = new Author
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName
            };

            if (services.FindAuthor(name) == null)
            {
                services.AddAuthor(authorToAdd);
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

            Author author = services.FindAuthor(id);

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

            Author author = services.FindAuthor(name);

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

            string countryName = services.GetAuthorCountry(author);
            string birthday = author.Birthday.ToString() != "" ? author.Birthday.ToString() : "Unknown";

            FullAuthorView result = new FullAuthorView
            {
                Id = author.Id,
                Name = name,
                BookCount = services.GetAuthorBooksCount(author),
                Birthday = birthday,
                Nickname = author.Nickname != null ? author.Nickname : "Unknown",
                Country = countryName
            };

            return result;
        }
    }
}
