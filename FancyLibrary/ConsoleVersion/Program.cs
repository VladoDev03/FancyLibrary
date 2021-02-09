using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ConsoleVersion.Models;
using CsvHelper;
using System.Linq;

namespace ConsoleVersion
{
    public class Program
    {
        static void Main(string[] args)
        {
            LocalDatabase localDatabase = new LocalDatabase();
            CommandInterpreter commandInterpreter = new CommandInterpreter(localDatabase);

            List<string> input = Console.ReadLine().Split().ToList();
            Console.WriteLine(commandInterpreter.RegisterUser(input));

            try
            {
                Console.WriteLine(commandInterpreter.LogoutUser());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            input = Console.ReadLine().Split().ToList();
            Console.WriteLine(commandInterpreter.LoginUser(input));

            Console.WriteLine(commandInterpreter.LogoutUser());

            //vlad111 Salamur$12 vlad vlado vladeto 17 2021-02-07
            //vlad111 Salamur$12
        }
    }
}
