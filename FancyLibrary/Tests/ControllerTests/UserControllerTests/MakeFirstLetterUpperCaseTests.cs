using ConsoleVersion.Controllers;
using ConsoleVersion.Models;
using ConsoleVersion.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ControllerTests.UserControllerTests
{
    public class MakeFirstLetterUpperCaseTests
    {
        FancyLibraryContext db;
        UserServices userServices;
        UserController userController;

        [SetUp]
        public void Setup()
        {
            db = new FancyLibraryContext();
            userServices = new UserServices(db);
            userController = new UserController(userServices);
        }

        [Test]
        public void IsSettingFirstLetterToUpperWhenNotNull()
        {
            string name = "gladen";

            name = userController.MakeFirstLetterUpperCase(name);

            Assert.That(name, Is.EqualTo("Gladen"));
        }

        [Test]
        public void IsNameNullWhenValueIsNull()
        {
            string name = null;

            name = userController.MakeFirstLetterUpperCase(name);

            Assert.That(name, Is.EqualTo(null));
        }
    }
}
