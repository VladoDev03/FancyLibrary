﻿using Data.Utils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace Data.Entities
{
    public partial class User : IdentityUser<int>
    {
        private const int MinNameLength = 3;
        private const int MinAge = 7;

        //private string userName;
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime birthday;
        private int age;

        public User()
        {
            UsersBooks = new HashSet<UserBook>();
        }

        //public int Id { get; set; }
        public override string UserName
        {
            get
            {
                return base.UserName;
            }
            set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.UserNameException, MinNameLength));
                }

                base.UserName = value;
            }
        }

        public string Password { get; set; }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.FirstNameException, MinNameLength));
                }

                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                if (value != null && value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.MiddleNameException, MinNameLength));
                }

                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.LastNameException, MinNameLength));
                }

                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.AgeException, MinAge));
                }

                age = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                if (value == default)
                {
                    throw new ArgumentException(ExceptionsTexts.NullBirthday);
                }

                birthday = value;
            }
        }

        public int? ContactId { get; set; }

        public int LogDataId { get; set; }

        public int? CountryId { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual Country Country { get; set; }

        public virtual LogData LogData { get; set; }

        public virtual ICollection<UserBook> UsersBooks { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"UserName - {UserName}");
            sb.AppendLine($"Password - {Password}");
            sb.AppendLine($"First name - {FirstName}");
            sb.AppendLine($"Middle name - {MiddleName}");
            sb.AppendLine($"Last name - {LastName}");
            sb.AppendLine($"Age - {Age}");

            return sb.ToString().Trim();
        }
    }
}
