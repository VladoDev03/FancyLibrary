using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Utils
{
    public static class ExceptionsText
    {
        public const string NotUserLoggedIn = "You cannot logout before logging in!";
        public const string NotExistingUser = "User with this username does not exist!";
        public const string AlreadyLoggedIn = "You are already logged in!";
    }
}
