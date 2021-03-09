using Data.Utils;
using NUnit.Framework;

namespace Tests.UtilsTests.PasswordManagerTests
{
    public class EncodePasswordTests
    {
        [Test]
        public void IsPasswordBeingEncodedRight()
        {
            string password = "Salamur$12";
            string expected = PasswordManager.EncodePassword(password);

            Assert.That(expected, Is.EqualTo("42)snncmfT"));
        }
    }
}
