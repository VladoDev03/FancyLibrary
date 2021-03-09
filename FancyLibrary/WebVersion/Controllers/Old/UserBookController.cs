using Services;

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
