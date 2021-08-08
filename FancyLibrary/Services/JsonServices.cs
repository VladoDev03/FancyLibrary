using Services.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class JsonServices : IJsonServices
    {
        public void MakeJsonFileBook(string content, string path)
        {
            File.WriteAllText(path, content);
        }

        public string BookListToJson(List<Book> books)
        {
            string result = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            return result;
        }
    }
}
