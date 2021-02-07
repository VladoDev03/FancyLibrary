using ConsoleVersion.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class DatabaseController
    {
        private IDatabase database;

        public DatabaseController(IDatabase database)
        {
            this.database = database;
        }

        public void AddUser(User user)
        {
            // vlad111 Salamur$12 vlad vlado vladeto 17 20-5-2003

            using SqlConnection connection = new SqlConnection("Server=.;Database=MyFancyCatalog;Integrated Security=true;");
            connection.Open();

            string username = user.Username;

            if (database.Users.Exists(u => u.Username == username))
            {
                throw new ArgumentException();
            }

            StringBuilder sbAddUser = new StringBuilder();

            sbAddUser.AppendLine("INSERT INTO Users (Username, [Password], FirstName, MiddleName, LastName, Age, BirthdayDate, LastTimeLoggedIn)");
            sbAddUser.Append($"VALUES (@username, @password, @firstName, @middleName, @lastName, @age, @birthdayDate, 2000-00-00);");

            using SqlCommand addUserCommand = new SqlCommand(sbAddUser.ToString(), connection);
            addUserCommand.Parameters.AddWithValue("@username", user.Username);
            addUserCommand.Parameters.AddWithValue("@password", user.Password);
            addUserCommand.Parameters.AddWithValue("@firstName", user.FirstName);
            addUserCommand.Parameters.AddWithValue("@middleName", user.MiddleName);
            addUserCommand.Parameters.AddWithValue("@lastName", user.LastName);
            addUserCommand.Parameters.AddWithValue("@age", user.Age);
            addUserCommand.Parameters.AddWithValue("@birthdayDate", user.BirthdayDate);

            addUserCommand.ExecuteNonQuery();
        }
    }
}
