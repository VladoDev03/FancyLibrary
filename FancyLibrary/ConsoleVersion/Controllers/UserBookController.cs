using ConsoleVersion.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class UserBookController
    {
        private UserBookServices userBookServices;

        public UserBookController(UserBookServices userBookServices)
        {
            this.userBookServices = userBookServices;
        }
    }
}
