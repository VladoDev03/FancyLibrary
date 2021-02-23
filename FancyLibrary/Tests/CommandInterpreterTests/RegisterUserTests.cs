using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.CommandInterpreterTests
{
    public class RegisterUserTests
    {
        [Test]
        public void ThrowsExceptionWhenUsernameIsTaken()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());
            List<string> input = new List<string>
            {
                "vladsto",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                "27",
                "1994-01-10",
            };

            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => commandInterpreter.RegisterUser(input));

            Assert.That(ae.Message, Is.EqualTo("This username is taken!"));
        }

        [Test]
        public void ThrowsExceptionWhenUserTriesToRegisterNewAccountBeforeLoggingOut()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            commandInterpreter.LoginUser(new List<string>() { "vladsto", "Salamur$12"});
            List<string> input = new List<string>
            {
                "vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                "27",
                "1994-01-10",
            };

            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => commandInterpreter.RegisterUser(input));

            Assert.That(ae.Message, Is.EqualTo("Log out before register new profile!"));
        }

        [Test]
        public void ReturnsCorrectMessageWhenSuccessfullyRegistered()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            List<string> input = new List<string>
            {
                "vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                "27"
            };

            Assert.That(commandInterpreter.RegisterUser(input),
                Is.EqualTo("You were successfuly registered!"));
        }

        [Test]
        public void UserLoggedInAfterRegistering()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            List<string> input = new List<string>
            {
                "vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                "27"
            };

            commandInterpreter.RegisterUser(input);

            Assert.That(commandInterpreter.CurrentLoggedInUser.Username, Is.EqualTo(input[0]));
        }
    }
}
