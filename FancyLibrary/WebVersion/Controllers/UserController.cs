using Data.Entities;
using Data.Models;
using Data.Utils;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            if (ValidatePropertiesRegister(user))
            {
                return View();
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
                LastTimeLoggedIn = default,
                IsOnline = false
            };

            try
            {
                userServices.SetAge(newUser);
            }
            catch (ArgumentException ae)
            {
                ViewData.Add("TooYoung", ae.Message);
                return View();
            }

            IdentityResult result = await userManager.CreateAsync(newUser, newUser.Password);

            if (!result.Succeeded)
            {
                ViewData.Add("PasswordErrors", result.Errors.First().Description);
                return View();
            }

            return RedirectToAction(nameof(Login));
        }

        private bool ValidatePropertiesRegister(UserDTO user)
        {
            if (userServices.FindUser(user.Username) != null)
            {
                ViewData.Add("ExistingUserError", "Username is taken!");
                return true;
            }

            if (string.IsNullOrEmpty(user.Username) || user.Username.Length < 3)
            {
                ViewData.Add("MissingUsername", "Username has to be minimum of 3 characters!");
                return true;
            }

            if (user.Password != user.ConfirmPassword || user.Password == null || user.ConfirmPassword == null)
            {
                ViewData.Add("NotMatchingPasswordsError", "Password must match confirm password!");
                return true;
            }

            if (string.IsNullOrEmpty(user.FirstName) || user.FirstName.Length < 3)
            {
                ViewData.Add("MissingFirstName", "First name has to be minimum of 3 characters!");
                return true;
            }

            if (string.IsNullOrEmpty(user.LastName) || user.LastName.Length < 3)
            {
                ViewData.Add("MissingLastName", "Last name has to be minimum of 3 characters!");
                return true;
            }

            if (string.IsNullOrEmpty(user.Birthday))
            {
                ViewData.Add("MissingBirthday", "Birthday is required!");
                return true;
            }

            return false;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO user)
        {
            if (ValidatePropertiesLogin(user))
            {
                return View();
            }

            // SignInResult
            var result = await signInManager
                .PasswordSignInAsync(user.Username, user.Password, false, false);

            if (!result.Succeeded)
            {
                ViewData.Add("WrongPasswordError", "Wrong username or password!");
                return View();
            }

            userServices.ChangesWhenLoggedIn(userServices.FindUser(user.Username));

            return RedirectToAction(nameof(Profile));
        }

        private bool ValidatePropertiesLogin(UserDTO user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                ViewData.Add("NullUsernameLogin", "Please type your username!");
                return true;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                ViewData.Add("NullPasswordLogin", "Please type your password!");
                return true;
            }

            return false;
        }

        public async Task<IActionResult> Logout()
        {
            User user = await userManager.GetUserAsync(User);

            userServices.ChangeStatus(user);

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            User user = await userManager.GetUserAsync(User);

            FullUserView fullUserView = userServices.GetAllData(user);

            List<Book> books = userBookServices.GetBooksOfUser(user);
            List<BookView> booksViews = userBookServices.GetBooksOfUserViews(books);

            fullUserView.Books.AddRange(booksViews);

            return View(fullUserView);
        }

        public async Task<IActionResult> RemoveBook(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Profile));
            }

            User user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction(nameof(Profile));
            }

            Book book = bookServices.FindBook(id);

            userBookServices.RemoveBookFromUser(user, book);

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public IActionResult AddContacts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts(string email, string phone)
        {
            User user = await userManager.GetUserAsync(User);

            try
            {
                userServices.AddContact(user, email, phone);
            }
            catch (ArgumentException ae)
            {
                ViewData.Add("TakenContact", ae.Message);
                return View();
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string oldPass, string newPass)
        {
            User user = await userManager.GetUserAsync(User);

            IdentityResult result = await userManager
                .ChangePasswordAsync(user, oldPass, newPass);

            if (!result.Succeeded)
            {
                ViewData.Add("PasswordNotChanged", result.Errors.First().Description);
                return View();
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserDTO newData)
        {
            User user = await userManager.GetUserAsync(User);

            try
            {
                userServices.ChangeUser(user, newData);
            }
            catch (ArgumentException ae)
            {
                ViewData.Add("InvalidName", ae.Message);
                return View();
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Profile));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string password)
        {
            User user = await userManager.GetUserAsync(User);

            bool result = await userManager.CheckPasswordAsync(user, password);

            if (!result)
            {
                ViewData.Add("WrongPassword", "Incorrect password!");
                return View();
            }

            userBookServices.DeleteAllBooks(user);

            await signInManager.SignOutAsync();
            await userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogData()
        {
            User user = await userManager.GetUserAsync(User);

            LogData data = userServices.FindLogData(user);

            return View(data);
        }
    }
}
