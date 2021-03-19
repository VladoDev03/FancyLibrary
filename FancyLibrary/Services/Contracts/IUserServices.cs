using Data.Entities;
using Data.Models;
using Data.ViewModels;
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

        void Delete(User user);

        void SetAge(User user);

        void AddEmail(User user, string email);

        void AddPhone(User user, string phone);

        void AddContact(User user, string email, string phone);

        void ChangeUser(User user, EditUserDTO newData);

        void ChangePassword(User user, string password);

        void ChangesWhenLoggedIn(User user);

        void ChangeStatus(User user);

        void IncreaseLogInCount(User user);

        void ChangeLastLogIn(User user);

        LogData FindLogData(User user);

        Contact FindUserContact(User user);

        FullUserView GetAllData(User user);
    }
}
