using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUserServices
    {
        List<User> GetAllUsers();

        User FindUser(int id);

        User FindUser(string UserName);

        void AddUser(User user);

        void SetAge(User user);

        void AddEmail(User user, string email);

        void AddPhone(User user, string phone);

        void ChangeUserName(User user, string UserName);

        void ChangePassword(User user, string password);

        //void ChangesWhenLoggedIn(User user);

        void ChangeStatus(User user);

        void IncreaseLogInCount(User user);

        void ChangeLastLogIn(User user);

        LogData FindLogData(User user);
    }
}
