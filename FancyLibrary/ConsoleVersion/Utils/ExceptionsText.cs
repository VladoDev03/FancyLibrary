using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleVersion.Utils
{
    public static class ExceptionsText
    {
        public const string NotUserLoggedIn = "You cannot logout before logging in!";
        public const string NotExistingUser = "User with this username does not exist!";
        public const string AlreadyLoggedIn = "You are already logged in!";
        public const string WrongPassword = "Invalid username or password!";
        public const string TakenUsername = "This username is taken!";
        public const string LogInCannotRegister = "Log out before register new profile!";

        public const string ShorterPassword = "Password must be atleast {0} characters long!";
        public const string LessUpperCase = "Password must contain at least {0} upper case letter!";
        public const string LessLowerCase = "Password must contain at least {0} lower case letter!";
        public const string LessDigits = "Password must contain at least {0} digit!";
        public const string LessSymbols = "Password must contain at least {0} symbol!";
    }
}
