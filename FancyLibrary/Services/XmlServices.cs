using Services.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Data.ViewModels;

namespace Services
{
    public class XmlServices : IXmlServices
    {
        public void MakeXmlFileBook(string content, string path)
        {
            File.WriteAllText(path, content);
        }

        public string BookListToXml(List<BookView> books)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<BookView>));

            xmlSerializer.Serialize(writer, books);

            return writer.ToString();
        }
    }
}
