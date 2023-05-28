using Microsoft.AspNetCore.Mvc;

namespace NBAProject.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
