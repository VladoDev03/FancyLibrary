using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
{
    public class UserServices
    {
        private FancyLibraryContext db;

        public UserServices(FancyLibraryContext db)
        {
            this.db = db;
        }

        public List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
        }
    }
}
