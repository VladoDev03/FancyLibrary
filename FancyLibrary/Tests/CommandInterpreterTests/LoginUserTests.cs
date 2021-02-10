using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.CommandInterpreterTests
{
    public class LoginUserTests
    {
        [Test]
        public void ThrowsExceptionWhenTryingToLogInWhenAlreadyLoggedIn()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            commandInterpreter.LoginUser(new List<string> { "vladsto", "Salamur$12" });

            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => commandInterpreter.LoginUser(
                    new List<string> { "vladsto", "Salamur$12" }));

            string result = ae.Message;
            string expected = "You are already logged in!";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ThrowsExceptionWhenThereIsNoUserWithThisUsername()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => commandInterpreter.LoginUser(
                    new List<string> { "vladst", "Salamur$12" }));

            string result = ae.Message;
            string expected = "User with this username does not exist!";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ThrowsExceptionWhenPasswordIsWrong()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => commandInterpreter.LoginUser(
                    new List<string> { "vladsto", "Salamur$1" }));

            string result = ae.Message;
            string expected = "Invalid username or password!";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReturnsCorrectMessageWhenSuccessfullyLoggedIn()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            string result = commandInterpreter.LoginUser(
                    new List<string> { "vladsto", "Salamur$12" });
            string expected = "Welcome again!";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
