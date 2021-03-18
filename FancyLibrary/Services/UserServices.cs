using Data.Entities;
using Data.Models;
using Data.Utils;
using Data.ViewModels;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserServices : IUserServices
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

        public User FindUser(string UserName)
        {
            return db.Users.FirstOrDefault(u => u.UserName == UserName);
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void SetAge(User user)
        {
            TimeSpan timeSpan = DateTime.Today - user.Birthday;
            int years = (new DateTime(1, 1, 1) + timeSpan).Year - 1;

            user.Age = years;

            db.SaveChanges();
        }

        public void AddEmail(User user, string email)
        {
            user.Contact = new Contact
            {
                Email = email
            };

            db.SaveChanges();
        }

        public void AddContact(User user, string email, string phone)
        {
            if (db.Contacts.FirstOrDefault(c => c.Email == email && email != null) != null)
            {
                throw new ArgumentException(ExceptionsTexts.RepeatEmail);
            }

            if (db.Contacts.FirstOrDefault(c => c.Phone == phone && phone != null) != null)
            {
                throw new ArgumentException(ExceptionsTexts.RepeatPhone);
            }

            Contact oldContact = FindUserContact(user);

            if (oldContact == null)
            {
                oldContact = new Contact();
            }

            if (email != null && email != oldContact.Email)
            {
                oldContact.Email = email;
            }

            if (phone != null && phone != oldContact.Phone)
            {
                oldContact.Phone = phone;
            }

            user.Contact = oldContact;

            db.SaveChanges();
        }

        public void AddPhone(User user, string phone)
        {
            user.Contact = new Contact
            {
                Phone = phone
            };

            db.SaveChanges();
        }

        public void ChangeUser(User user, EditUserDTO newData)
        {
            if (FindUser(newData.Username) != null)
            {
                throw new ArgumentException(ExceptionsTexts.RepeatingUsername);
            }
            if (newData.Username != null && newData.Username != user.UserName)
            {
                user.UserName = newData.Username;
            }
            if (newData.FirstName != null && newData.FirstName != user.FirstName)
            {
                user.FirstName = newData.FirstName;
            }
            if (newData.MiddleName != null && newData.MiddleName != user.MiddleName)
            {
                user.MiddleName = newData.MiddleName;
            }
            if (newData.LastName != null && newData.LastName != user.LastName)
            {
                user.LastName = newData.LastName;
            }

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

        public LogData FindLogData(User user)
        {
            LogData logData = db.LogData.FirstOrDefault(lg => lg.Id == user.LogDataId);
            return logData;
        }

        public FullUserView GetAllData(User user)
        {
            if (user == null)
            {
                return null;
            }

            FullUserView fullUserView = new FullUserView();

            fullUserView.Username = user.UserName;
            fullUserView.FirstName = user.FirstName;
            fullUserView.MiddleName = user.MiddleName != null ? user.MiddleName : "Empty";
            fullUserView.LastName = user.LastName;
            fullUserView.BooksCount = db.UsersBooks
                .Where(ub => ub.UserId == user.Id)
                .Count();

            Contact contact = FindUserContact(user);

            if (contact != null)
            {
                fullUserView.Email = contact.Email != null ? contact.Email : "Empty";
                fullUserView.Phone = contact.Phone != null ? contact.Phone : "Empty";
            }
            else
            {
                fullUserView.Email = "Empty";
                fullUserView.Phone = "Empty";
            }

            return fullUserView;
        }

        public Contact FindUserContact(User user)
        {
            if (user == null)
            {
                return null;
            }

            return db.Contacts.FirstOrDefault(c => c.Id == user.ContactId);
        }
    }
}
