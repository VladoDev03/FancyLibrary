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
    }
}
