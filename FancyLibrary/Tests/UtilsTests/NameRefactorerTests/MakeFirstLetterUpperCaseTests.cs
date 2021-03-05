using ConsoleVersion.Controllers;
using ConsoleVersion.Models;
using ConsoleVersion.Services;
using ConsoleVersion.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UtilsTests.NameRefactorerTests
{
    public class MakeFirstLetterUpperCaseTests
    {
        [Test]
        public void IsSettingFirstLetterToUpperWhenNotNull()
        {
            string name = "gladen";

            name = NameRefactorer.MakeFirstLetterUpperCase(name);

            Assert.That(name, Is.EqualTo("Gladen"));
        }

        [Test]
        public void IsNameNullWhenValueIsNull()
        {
            string name = null;

            name = NameRefactorer.MakeFirstLetterUpperCase(name);

            Assert.That(name, Is.EqualTo(null));
        }
    }
}
