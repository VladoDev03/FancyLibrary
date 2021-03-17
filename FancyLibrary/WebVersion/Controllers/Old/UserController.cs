using Data.Entities;
using Data.Utils;
using Services;
using System;
using System.Collections.Generic;

namespace ConsoleVersion.Controllers
{
    public class UserController
    {
        private UserServices userServices;

        public UserController(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public User CurrentLoggedInUser { get; private set; }

        public string LoginUser(List<string> input)
        {
            if (CurrentLoggedInUser != null)
            {
                throw new ArgumentException(ExceptionsTexts.AlreadyLoggedIn);
            }

            string UserName = input[0];
            string password = PasswordManager.EncodePassword(input[1]);

            User user = userServices.FindUser(UserName);

            if (user == null)
            {
                throw new ArgumentException(ExceptionsTexts.NotExistingUser);
            }

            if (password != user.Password)
            {
                throw new ArgumentException(ExceptionsTexts.WrongPassword);
            }

            CurrentLoggedInUser = user;

            //userServices.ChangesWhenLoggedIn(user);
            userServices.ChangeLastLogIn(user);
            userServices.ChangeStatus(user);
            userServices.IncreaseLogInCount(user);

            return MessagesToUser.WelcomeMessage;
        }

        public string LogoutUser()
        {
            if (CurrentLoggedInUser == null)
            {
                throw new ArgumentException(ExceptionsTexts.NotUserLoggedIn);
            }

            userServices.ChangeStatus(CurrentLoggedInUser);

            CurrentLoggedInUser = null;
            return MessagesToUser.LogOutMessage;
        }

        public string RegisterUser(List<string> input)
        {
            if (CurrentLoggedInUser != null)
            {
                throw new ArgumentException(ExceptionsTexts.LogInCannotRegister);
            }

            string UserName = input[0];
            string password = input[1];
            string firstName = input[2];
            string lastName = input[3];
            DateTime birthday = DateTime.Parse(input[4]);

            PasswordManager.IsPasswordValid(password);

            if (userServices.FindUser(UserName) != null)
            {
                throw new ArgumentException(ExceptionsTexts.TakenUserName);
            }

            User user = new User
            {
                UserName = UserName,
                //Password = PasswordManager.EncodePassword(password),
                FirstName = NameRefactorer.MakeFirstLetterUpperCase(firstName),
                LastName = NameRefactorer.MakeFirstLetterUpperCase(lastName),
                Birthday = birthday,
                LogData = new LogData
                {
                    LastTimeLoggedIn = DateTime.Now,
                    TimesLoggedIn = 0,
                    RegisterDate = DateTime.Now,
                    IsOnline = true
                }
            };

            userServices.SetAge(user);

            userServices.AddUser(user);

            LoginUser(new List<string> { UserName, password });

            return MessagesToUser.RegisterMessage;
        }
    }
}
