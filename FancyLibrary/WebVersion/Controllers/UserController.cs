using Data.Entities;
using Data.Models;
using Data.Utils;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVersion.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IUserServices userServices;
        private IUserBookServices userBookServices;
        private IBookServices bookServices;

        public UserController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserServices userServices,
            IUserBookServices userBookServices,
            IBookServices bookServices)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userServices = userServices;
            this.userBookServices = userBookServices;
            this.bookServices = bookServices;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            if (string.IsNullOrEmpty(user.Username)
                || string.IsNullOrEmpty(user.Password)
                || string.IsNullOrEmpty(user.ConfirmPassword)
                || string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName))
            {
                return RedirectToAction(nameof(Register));
            }

            if (user.Password != user.ConfirmPassword)
            {
                return RedirectToAction(nameof(Register));
            }

            User newUser = new User();
            newUser.UserName = user.Username;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Password = user.Password;
            newUser.Birthday = DateTime.Parse(user.Birthday);
            newUser.EmailConfirmed = true;
            newUser.LogData = new LogData
            {
                TimesLoggedIn = 0,
                RegisterDate = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                IsOnline = true
            };

            IdentityResult result = await userManager.CreateAsync(newUser, newUser.Password);

            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Register));
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO user)
        {
            if (string.IsNullOrEmpty(user.Username)
                   || string.IsNullOrEmpty(user.Password))
            {
                return RedirectToAction(nameof(Login));
            }

            // SignInResult
            var result = await signInManager
                .PasswordSignInAsync(user.Username, user.Password, false, false);

            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            User user = await userManager.GetUserAsync(User);

            FullUserView fullUserView = userServices.GetAllData(user);
            List<Book> books = userBookServices.GetBooksOfUser(user);

            foreach (var item in books)
            {
                Author author = bookServices.GetBookAuthor(item);

                BookView bookView = new BookView
                {
                    Title = item.Title,
                    Genre = item.Genre,
                    AuthorName = NameRefactorer
                    .GetFullName(author.FirstName, author.MiddleName, author.LastName)
                };

                fullUserView.Books.Add(bookView);
            }

            return View(fullUserView);
        }
    }
}
