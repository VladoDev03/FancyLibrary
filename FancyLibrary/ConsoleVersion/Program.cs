using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ConsoleVersion.Models;
using CsvHelper;
using System.Linq;
using ConsoleVersion.Services;
using ConsoleVersion.Controllers;

namespace ConsoleVersion
{
    public class Program
    {
        static void Main(string[] args)
        {
            FancyLibraryContext db = new FancyLibraryContext();

            UserServices userServices = new UserServices(db);
            UserController userController = new UserController(userServices);

            int n = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine().Split().ToList();

            if (n == 1)
            {
                Console.WriteLine(userController.RegisterUser(input));
            }
            else
            {
                Console.WriteLine(userController.LoginUser(input));
            }

            //vlad111 Salamur$12 vlad vlado vladeto 17 2021-02-07
            //vlad111 Salamur$12
        }
    }
}
