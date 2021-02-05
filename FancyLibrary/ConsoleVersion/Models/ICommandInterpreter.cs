using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public interface ICommandInterpreter
    {
        public IDatabase Database { get; }

        public User CurrentLoggedInUser { get; }

        string LoginUser(List<string> input);

        string RegisterUser(List<string> input);

        string LogoutUser(User user);

        string EncodePassword(string username);
    }
}
