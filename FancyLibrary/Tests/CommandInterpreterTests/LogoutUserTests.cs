using ConsoleVersion.Models;
using NUnit.Framework;
using System;

namespace Tests
{
    public class LogoutUserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            //Assert.That(commandInterpreter.LogoutUser(), Throws.ArgumentException.With.Message.EqualTo("You cannot logout before logging in!"));
            //Assert.Throws(commandInterpreter.LogoutUser(), "You cannot logout before logging in!");

            ArgumentException ex = Assert.Throws<ArgumentException>(() => commandInterpreter.LogoutUser());
            Assert.That(ex.Message, Is.EqualTo("You cannot logout before logging in!"));

        }
    }
}