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

        public User FindUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public User FindUser(string username)
        {
            return db.Users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void AddBookToUser(User user, Book book)
        {
            db.UsersBooks.Add(new UserBook
            {
                UserId = user.Id,
                BookId = book.Id
            });

            db.SaveChanges();
        }

        public void AddEmail(User user, string email)
        {
            if (user.Contact == null)
            {
                user.Contact = new Contact();
            }

            user.Contact.Email = email;

            db.SaveChanges();
        }

        public void AddPhone(User user, string phone)
        {
            if (user.Contact == null)
            {
                user.Contact = new Contact();
            }

            user.Contact.Phone = phone;

            db.SaveChanges();
        }

        public void ChangeUsername(User user, string username)
        {
            user.Username = username;

            db.SaveChanges();
        }

        public void ChangePassword(User user, string password)
        {
            user.Password = password;

            db.SaveChanges();
        }

        public void ChangesWhenLoggedIn(User user)
        {
            ChangeStatus(user);
            IncreaseLogInCount(user);
            ChangeLastLogIn(user);
        }

        public void ChangeStatus(User user)
        {
            LogData logData = FindLogData(user);

            if (logData.IsOnline)
            {
                logData.IsOnline = false;
            }
            else
            {
                logData.IsOnline = true;
            }

            db.SaveChanges();
        }

        public void IncreaseLogInCount(User user)
        {
            LogData logData = FindLogData(user);
            logData.TimesLoggedIn++;

            db.SaveChanges();
        }

        public void ChangeLastLogIn(User user)
        {
            LogData logData = FindLogData(user);
            logData.LastTimeLoggedIn = DateTime.Now;

            db.SaveChanges();
        }

        private LogData FindLogData(User user)
        {
            LogData logData = db.LogData.FirstOrDefault(lg => lg.Id == user.LogDataId);
            return logData;
        }
    }
}
