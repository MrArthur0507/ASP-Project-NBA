using Microsoft.AspNetCore.Mvc;

namespace NBAProject.Controllers
{
    public class StatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
