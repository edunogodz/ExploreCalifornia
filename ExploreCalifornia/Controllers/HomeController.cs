using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class HomeController
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Hello, ASP NET CORE MVC" };
        }
    }
}
