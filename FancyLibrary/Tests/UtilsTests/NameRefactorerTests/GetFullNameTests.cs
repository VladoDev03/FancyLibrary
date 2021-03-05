using System;
using System.Collections.Generic;
using System.Text;
using ConsoleVersion.Controllers;
using ConsoleVersion.Models;
using ConsoleVersion.Services;
using ConsoleVersion.Utils;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests.UtilsTests.NameRefactorerTests
{
    public class GetFullNameTests
    {
        [Test]
        public void ReturnTwoNamesIfMiddleIsNull()
        {
            string result = NameRefactorer.GetFullName("Vladimir", null, "Stoyanov");
            Assert.That(result, Is.EqualTo("Vladimir Stoyanov"));
        }

        [Test]
        public void ReturnThreeNumbersWhenMiddleNameIsNotNull()
        {
            string result = NameRefactorer.GetFullName("Vladimir", "Rumenov", "Stoyanov");
            Assert.That(result, Is.EqualTo("Vladimir Rumenov Stoyanov"));
        }
    }
}
