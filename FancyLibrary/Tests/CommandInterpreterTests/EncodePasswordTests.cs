using ConsoleVersion.Models;
using NUnit.Framework;

namespace EncodePasswordTests
{
    public class EncodePasswordTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(new LocalDatabase());

            string password = "Salamur$12";

            Assert.That(commandInterpreter.EncodePassword(password), Is.EqualTo("42)snncmfT"));
        }
    }
}