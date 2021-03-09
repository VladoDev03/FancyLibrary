using Data.Entities;
using NUnit.Framework;
using System;

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

            ArgumentException ae = Assert.Throws<ArgumentException>(() => contact = new Contact
            {
                Email = "asdasdasdasd",
                Phone = "1234567890"
            });

            Assert.That(ae.Message, Is.EqualTo("This email is invalid, try with another one!"));
        }

        [Test]
        public void IsEmailSettingWhenItIsValid()
        {
            Contact contact = new Contact
            {
                Email = "asdasd@asdasd",
                Phone = "1234567890"
            };

            Assert.That(contact.Email, Is.EqualTo("asdasd@asdasd"));
        }

        [Test]
        public void IsPhoneThrowingRightExceptionWhenInvalid()
        {
            Contact contact = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => contact = new Contact
            {
                Email = "asdasd@asdasd",
                Phone = "123456789"
            });

            Assert.That(ae.Message, Is.EqualTo("This phone number is invalid, try with another one!"));
        }

        [Test]
        public void IsPhoneSettingWhenItIsValid()
        {
            Contact contact = new Contact
            {
                Email = "asdasd@asdasd",
                Phone = "1234567890"
            };

            Assert.That(contact.Phone, Is.EqualTo("1234567890"));
        }

        [Test]
        public void IsIdReturnedCorrectly()
        {
            Contact contact = new Contact
            {
                Id = 1,
                Email = "asdasd@asdasd",
                Phone = "1234567890"
            };

            Assert.That(contact.Id, Is.EqualTo(1));
        }

        [Test]
        public void IsToStringReturningCorrectValues()
        {
            string correct = $"Id - 1{Environment.NewLine}Email - asdasd@asdasd{Environment.NewLine}Phone - 1234567890";

            Contact contact = new Contact
            {
                Id = 1,
                Email = "asdasd@asdasd",
                Phone = "1234567890"
            };

            Assert.That(contact.ToString(), Is.EqualTo(correct));
        }
    }
}
