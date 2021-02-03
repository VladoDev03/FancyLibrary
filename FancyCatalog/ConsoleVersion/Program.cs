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

            localDatabase.PrintAll();
        }
    }
}
