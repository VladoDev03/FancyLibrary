using CsvHelper;
using Services.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Services
{
    public class CsvServices : ICsvServices
    {
        public void MakeCsvFileBook(string content, string path)
        {
            File.WriteAllText(path, content);
        }

        public string BookListToCsv(List<Book> books)
        {
            StringWriter writer = new StringWriter();
            using CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(books);
            return writer.ToString();
        }
    }
}
