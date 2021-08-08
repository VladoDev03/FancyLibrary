using Services.Contracts;
using Data.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Services
{
    public class QrCodeServices : IQrCodeServices
    {
        public void MakeQrCode(string content, string path)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator gen = new QRCodeGenerator();
                QRCodeData MyData = gen.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(MyData);

                using (Bitmap map = code.GetGraphic(20))
                {
                    //map.Save(ms, ImageFormat.Png);
                    map.Save(path, ImageFormat.Png);
                }

                //return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
        }

        public string BookListToQrCode(List<Book> books)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Book book in books)
            {
                sb.AppendLine(book.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
