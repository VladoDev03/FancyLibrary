using ConsoleVersion.Controllers;
using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const int MinPasswordLength = 7;
        private const int MinSymbolsCount = 1;
        private const int MinNumbersCount = 1;
        private const int MinUpperCaseLettersCount = 1;
        private const int MinLowerCaseLettersCount = 1;

        public CommandInterpreter(IDatabase database)
        {
            Database = database;
        }

        public IDatabase Database { get; private set; }

        public User CurrentLoggedInUser { get; private set; }

        public string EncodePassword(string password)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = password.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    sb.Append((char)(password[i] + 1));
                }
                else if (i % 3 == 0)
                {
                    sb.Append((char)(password[i] + 2));
                }
                else if (i % 5 == 0)
                {
                    sb.Append((char)(Math.Abs(password[i] - 7)));
                }
                else
                {
                    sb.Append((char)(password[i] + 5));
                }
            }

            return sb.ToString();
        }

        public string LoginUser(List<string> input)
        {
            if (CurrentLoggedInUser != null)
            {
                throw new ArgumentException(ExceptionsTexts.AlreadyLoggedIn);
            }

            string username = input[0];
            string password = EncodePassword(input[1]);

            User user = Database.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException(ExceptionsTexts.NotExistingUser);
            }

            if (password != user.Password)
            {
                throw new ArgumentException(ExceptionsTexts.WrongPassword);
            }

            CurrentLoggedInUser = user;
            return MessagesToUser.WelcomeMessage;
        }

        public string LogoutUser()
        {
            if (CurrentLoggedInUser == null)
            {
                throw new ArgumentException(ExceptionsTexts.NotUserLoggedIn);
            }

            CurrentLoggedInUser = null;
            return MessagesToUser.LogOutMessage;
        }

        public string RegisterUser(List<string> input)
        {
            if (CurrentLoggedInUser != null)
            {
                throw new ArgumentException(ExceptionsTexts.LogInCannotRegister);
            }

            string username = input[0];
            string password = input[1];
            string firstName = input[2];
            string middleName = input[3];
            string lastName = input[4];
            int age = int.Parse(input[5]);

            IsPasswordValid(password);

            if (Database.Users.Exists(u => u.Username == username))
            {
                throw new ArgumentException(ExceptionsTexts.TakenUsername);
            }

            User user = new User
            {
                Username = username,
                Password = EncodePassword(password),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Age = age,
                LogData = new LogData
                {
                    LastTimeLoggedIn = DateTime.Now,
                    TimesLoggedIn = 1,
                    RegisterDate = DateTime.Now,
                    IsOnline = true
                }
            };

            Database.Users.Add(user);

            LoginUser(new List<string> { username, password });

            return MessagesToUser.RegisterMessage;
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length < MinPasswordLength)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.ShorterPassword, MinPasswordLength));
            }
            if (password.Where(x => char.IsUpper(x)).ToArray().Length < MinUpperCaseLettersCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessUpperCase, MinUpperCaseLettersCount));
            }
            if (password.Where(x => char.IsLower(x)).ToArray().Length < MinLowerCaseLettersCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessLowerCase, MinLowerCaseLettersCount));
            }
            if (password.Where(x => char.IsDigit(x)).ToArray().Length < MinNumbersCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessDigits, MinNumbersCount));
            }
            if (password.Where(x => char.IsSymbol(x)).ToArray().Length < MinSymbolsCount)
            {
                throw new ArgumentException(string.Format(ExceptionsTexts.LessSymbols, MinSymbolsCount));
            }

            return true;
        }
    }
}
