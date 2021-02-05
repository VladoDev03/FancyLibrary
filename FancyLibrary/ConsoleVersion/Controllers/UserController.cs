using ConsoleVersion.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class UserController
    {
        private const string ConnectionString = "Server=.;Database=MyFancyCatalog;Integrated Security=true;";
        //private IDatabase database;

        //public UserController()
        //{
        //    database = new RemoteDatabase();
        //}

        public void ChangeUserStatus(User user)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Users");

            if (user.IsOnline)
            {
                sb.AppendLine($"SET IsOnline = 1");
                user.IsOnline = true;
            }
            else
            {
                sb.AppendLine($"SET IsOnline = 0");
                user.IsOnline = false;
            }

            sb.AppendLine($"WHERE Id = {user.Id};");

            using SqlCommand command = new SqlCommand(sb.ToString().Trim(), connection);
            command.ExecuteNonQuery();
        }

        public void SetLoginTime(User user)
        {
            user.LastTimeLoggedIn = DateTime.Now.Date;
            using SqlConnection connection = new SqlConnection(ConnectionString);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE Users");
            sb.AppendLine($"SET IsOnline = {user.LastTimeLoggedIn}");

            sb.AppendLine($"WHERE Id = {user.Id};");

            using SqlCommand command = new SqlCommand(sb.ToString().Trim(), connection);
            command.ExecuteNonQuery();
        }
    }
}
