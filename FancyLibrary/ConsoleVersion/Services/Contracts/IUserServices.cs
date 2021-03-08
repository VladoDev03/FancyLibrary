using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Services.Contracts
{
    public interface IUserServices
    {
        List<User> GetAllUsers();

        User FindUser(int id);

        User FindUser(string username);

        void AddUser(User user);

        void SetAge(User user);

        void AddEmail(User user, string email);

        void AddPhone(User user, string phone);

        void ChangeUsername(User user, string username);

        void ChangePassword(User user, string password);

        void ChangesWhenLoggedIn(User user);

        void ChangeStatus(User user);

        void IncreaseLogInCount(User user);

        void ChangeLastLogIn(User user);

        LogData FindLogData(User user);
    }
}
