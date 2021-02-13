using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ModelsTests
{
    public class ContactTests
    {
        //"This email is invalid, try with another one!";
        //"This phone number is invalid, try with another one!";

        [Test]
        public void IsEmailThrowingRightExceptionWhenInvalid()
        {
            Contact contact = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => contact = new Contact("asdasdasdasd", "1234567890"));

            Assert.That(ae.Message, Is.EqualTo("This email is invalid, try with another one!"));
        }

        [Test]
        public void IsPhoneThrowingRightExceptionWhenInvalid()
        {
            Contact contact = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => contact = new Contact("asdasd@asdasd", "123456789"));

            Assert.That(ae.Message, Is.EqualTo("This phone number is invalid, try with another one!"));
        }
    }
}
