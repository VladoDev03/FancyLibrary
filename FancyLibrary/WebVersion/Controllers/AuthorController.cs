using Data.Entities;
using Data.Models;
using Data.Utils;
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
        public IActionResult Create(AuthorDTO author)
        {
            Author authorToAdd = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            string fullName = NameRefactorer
                .GetFullName(authorToAdd.FirstName, authorToAdd.MiddleName, authorToAdd.LastName);

            if (services.FindAuthor(fullName) == null)
            {
                services.AddAuthor(authorToAdd);
            }

            return RedirectToAction(nameof(Authors));
        }
    }
}
