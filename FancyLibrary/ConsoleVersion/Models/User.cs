using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Models
{
    public class User
    {
        private const int MinNameLength = 3;
        private const int MinAge = 7;

        private string username;
        private string password;
        private string firstName;
        private string middleName;
        private string lastName;
        private int age;

        public User()
        {

        }

        public User(string username, string password, string firstName, string middleName, string lastName, int age, DateTime birthdayDate, DateTime lastTimeLoggedIn, bool isOnline)
        {
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

        public User(int id, string username, string password, string firstName, string middleName, string lastName, int age, DateTime birthdayDate, DateTime lastTimeLoggedIn, bool isOnline)
            : this(username, password, firstName, middleName, lastName, age, birthdayDate, lastTimeLoggedIn, isOnline)
        {
            Id = id;
        }

        public int Id { get; set; }

        //TODO: add exception message.
        public string Username
        {
            get
            {
                return username;
            }
            private set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                username = value;
            }
        }

        //TODO: add exception message.
        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                password = value;
            }
        }

        //TODO: add exception message.
        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                firstName = value;
            }
        }

        //TODO: add exception message.
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            private set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException();
                }

                middleName = value;
            }
        }

        //TODO: add exception message.
        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException();
                }

                lastName = value;
            }
        }

        //TODO: add exception message.
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException();
                }

                age = value;
            }
        }

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
