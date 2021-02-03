using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string username, string password, string firstName, string middleName, string lastName, int age, DateTime birthdayDate, DateTime lastTimeLoggedIn, bool isOnline)
        {
            Id = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            BirthdayDate = birthdayDate;
            LastTimeLoggedIn = lastTimeLoggedIn;
            IsOnline = isOnline;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthdayDate { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public bool IsOnline { get; set; }

        public Contact Contact { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"Username - {Username}");
            sb.AppendLine($"Password - {Password}");
            sb.AppendLine($"First name - {FirstName}");
            sb.AppendLine($"Middle name - {MiddleName}");
            sb.AppendLine($"Last name - {LastName}");
            sb.AppendLine($"Age - {Age}");
            sb.AppendLine($"Birthday date - {BirthdayDate.Day}-{BirthdayDate.Month}-{BirthdayDate.Year}");
            sb.AppendLine($"Last time logged in - {LastTimeLoggedIn.Day}-{LastTimeLoggedIn.Month}-{LastTimeLoggedIn.Year}");
            sb.AppendLine($"Is online - {IsOnline}");

            return sb.ToString().Trim();
        }
    }
}
