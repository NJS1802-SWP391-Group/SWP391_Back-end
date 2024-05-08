using Microsoft.AspNetCore.Mvc;

namespace SWP391_Project.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
