using Data.Entities;
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

        public IActionResult Authors()
        {
            List<Author> authors = services.GetAllAuthors();
            return View(authors);
        }
    }
}
