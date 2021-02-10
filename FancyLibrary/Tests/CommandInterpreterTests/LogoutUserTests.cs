using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.CommandInterpreterTests
{
    public class LogoutUserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThrowsExceptionWhenTryingToLogOutBeforeLoggingIn()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            Assert.That(() => commandInterpreter.LogoutUser(),
                Throws.ArgumentException
                .With.Message
                .EqualTo("You cannot logout before logging in!"));

            //ArgumentException ex = Assert.Throws<ArgumentException>(() => commandInterpreter.LogoutUser());
            //Assert.That(ex.Message, Is.EqualTo("You cannot logout before logging in!"));
            //Assert.Throws<ArgumentException>(() => commandInterpreter.LogoutUser(), "You cannot logout before logging in!");
        }

        [Test]
        public void ReturningCorrectMessageWhenLoggingOutSuccessfuly()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());
            commandInterpreter.LoginUser(new List<string> { "vladsto", "Salamur$12" });

            string output = commandInterpreter.LogoutUser();

            Assert.That(output, Is.EqualTo("Have a nice day! We hope to see you soon!"));
        }
    }
}
