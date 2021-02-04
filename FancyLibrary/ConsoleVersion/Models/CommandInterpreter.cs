using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter(IDatabase database)
        {
            Database = database;
        }

        public IDatabase Database { get; private set; }

        public User CurrentLoggedInUser { get; private set; }

        //TODO
        //To be tested
        public string EncodePassword(string username)
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

            User user = Database.Users.FirstOrDefault(u => u.Username == CurrentLoggedInUser.Username);

            if (user == null)
            {
                throw new ArgumentException(ExceptionsText.NotExistingUser);
            }

            //TODO: add checker for password!

            return MessagesToUser.WelcomeMessage;
        }

        //To be tested
        public string LogoutUser(string username)
        {
            if (CurrentLoggedInUser == null)
            {
                throw new ArgumentException(ExceptionsText.NotUserLoggedIn);
            }

            CurrentLoggedInUser = null;
            return MessagesToUser.LogOutMessage;
            //return $"Have a nice day {CurrentLoggedInUser.Username}! We hope to see you soon!";
        }

        //TODO
        //To be tested
        public string RegisterUser(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
