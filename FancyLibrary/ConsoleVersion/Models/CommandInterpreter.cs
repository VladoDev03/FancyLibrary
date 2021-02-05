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
        private UserController userController;

        public CommandInterpreter(IDatabase database)
        {
            Database = database;
            //userController = new UserController();
        }

        public IDatabase Database { get; private set; }

        public User CurrentLoggedInUser { get; private set; }

        //TODO
        //To be tested
        public string EncodePassword(string password)
        {
            throw new NotImplementedException();
        }

        //TODO
        //To be tested
        public string LoginUser(List<string> input)
        {
            if (CurrentLoggedInUser != null)
            {
                throw new ArgumentException(ExceptionsText.AlreadyLoggedIn);
            }

            string username = input[0];
            string password = input[1];

            User user = Database.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException(ExceptionsText.NotExistingUser);
            }

            if (EncodePassword(password) != user.Password)
            {
                throw new ArgumentException(ExceptionsText.WrongPassword);
            }

            userController.ChangeUserStatus(user);
            userController.SetLoginTime(user);

            return MessagesToUser.WelcomeMessage;
        }

        //To be tested
        public string LogoutUser(User user)
        {
            if (CurrentLoggedInUser == null)
            {
                throw new ArgumentException(ExceptionsText.NotUserLoggedIn);
            }

            userController.ChangeUserStatus(user);

            CurrentLoggedInUser = null;
            return MessagesToUser.LogOutMessage;
        }

        //TODO
        //To be tested
        public string RegisterUser(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
