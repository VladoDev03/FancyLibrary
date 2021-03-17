using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVersion.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        //private UserServices userServices;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
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
            newUser.LogData = new LogData
            {
                TimesLoggedIn = 1,
                RegisterDate = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                IsOnline = true
            };

            IdentityResult result = await userManager.CreateAsync(newUser, newUser.Password);

            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Register));
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
