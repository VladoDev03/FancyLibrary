using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVersion.Controllers
{
    public class RestApiController : Controller
    {
        private IUserBookServices userBookServices;
        private IUserServices userServices;
        private IJsonServices jsonServices;
        private IXmlServices xmlServices;
        private ICsvServices csvServices;
        private IQrCodeServices qrCodeServices;
        private IBookServices bookServices;

        public RestApiController(
            IUserBookServices userBookServices,
            IUserServices userServices,
            IJsonServices jsonServices,
            IXmlServices xmlServices,
            ICsvServices csvServices,
            IQrCodeServices qrCodeServices,
            IBookServices bookServices)
        {
            this.userBookServices = userBookServices;
            this.userServices = userServices;
            this.jsonServices = jsonServices;
            this.xmlServices = xmlServices;
            this.csvServices = csvServices;
            this.qrCodeServices = qrCodeServices;
            this.bookServices = bookServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("books/json/{id}/{isNull}")]
        public string ReturnJsonString(int id, bool isNull)
        {
            List<BookView> booksToShow = GetBooks(id);

            string result = jsonServices.BookListToJson(booksToShow, isNull);

            return result;
        }

        [HttpGet("books/xml/{id}")]
        public string ReturnXmlString(int id)
        {
            List<BookView> booksToShow = GetBooks(id);

            string result = xmlServices.BookListToXml(booksToShow);

            return result;
        }

        [HttpGet("books/csv/{id}")]
        public string ReturnCsvString(int id)
        {
            List<BookView> booksToShow = GetBooks(id);

            string result = csvServices.BookListToCsv(booksToShow);

            return result;
        }

        [HttpGet("books/qr/{id}")]
        public IActionResult QrCode(int id)
        {
            List<BookView> booksToShow = GetBooks(id);

            string content = qrCodeServices.BookListToQrCode(booksToShow);
            ViewBag.QRCode = qrCodeServices.MakeQrCode(content);

            return View();
        }

        private List<BookView> GetBooks(int id)
        {
            User user = userServices.FindUser(id);

            List<Book> books = userBookServices.GetBooksOfUser(user);
            List<BookView> booksToShow = bookServices.GetBookList(books);

            return booksToShow;
        }
    }
}
