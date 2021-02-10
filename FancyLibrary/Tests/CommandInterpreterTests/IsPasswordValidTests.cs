using ConsoleVersion.Models;
using NUnit.Framework;
using System;

namespace Tests.CommandInterpreterTests
{
    public class IsPasswordValidTests
    {
        private CommandInterpreter commandInterpreter;

        [SetUp]
        public void Setup()
        {
            commandInterpreter = new CommandInterpreter(new LocalDatabase());
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordIsShorter()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => commandInterpreter.IsPasswordValid("Sa$1"));

            Assert.That(ae.Message, Is.EqualTo("Password must be atleast 7 characters long!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessUpperCaseLetters()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => commandInterpreter.IsPasswordValid("salamur$12"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 upper case letter!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessLowerCaseLetters()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => commandInterpreter.IsPasswordValid("SALAMUR$12"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 lower case letter!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessDigits()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => commandInterpreter.IsPasswordValid("Salamur$"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 digit!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessSymbols()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => commandInterpreter.IsPasswordValid("Salamur12"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 symbol!"));
        }
    }
}
