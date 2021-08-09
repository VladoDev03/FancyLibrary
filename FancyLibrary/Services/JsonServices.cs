using Services.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Data.ViewModels;

namespace Services
{
    public class JsonServices : IJsonServices
    {
        public void MakeJsonFileBook(string content, string path)
        {
            File.WriteAllText(path, content);
        }

        public string BookListToJson(List<BookView> books)
        {
            string result = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreNullValues = true
            });

            return result;
        }

        public string BookListToJson(List<BookView> books, bool isNull)
        {
            string result = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreNullValues = isNull
            });

            return result;
        }
    }
}
