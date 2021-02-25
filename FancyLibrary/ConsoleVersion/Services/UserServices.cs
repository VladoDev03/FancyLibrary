using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
{
    public static class UserServices
    {
        private static FancyLibraryContext db;

        static UserServices()
        {
            db = new FancyLibraryContext();
        }

        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static void AddUser(User user)
        {
            db.Users.Add(user);
        }
    }
}
