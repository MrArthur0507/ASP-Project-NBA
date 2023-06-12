using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;

namespace NBAProject.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerCrudOperations _playerService;

        private readonly ApplicationDbContext _context;
        public PlayerController(IPlayerCrudOperations playerCrudOperations, ApplicationDbContext context)
        {
            _playerService= playerCrudOperations;
            _context= context;
        }
        public  IActionResult Index(int page)
        {
            return View(_playerService.GetByPage(page));
        }

        public async Task<IActionResult> Details(int id)
        {
            PlayerDetailsViewModel player = await _playerService.GetById(id);
            return View(player);
        }

        public async Task<IActionResult> Create()
        {
            
            return View(await _playerService.Create());
        }

        public async Task<IActionResult> GetStats(int id)
        {
            List<Stat> stats = _context.Stats.Where(stats => stats.PlayerId == id).ToList();
            Dictionary<string, double?> statsAverage= new Dictionary<string, double?>();

            statsAverage.Add("Points", stats.Average(stat => stat.Points));
            statsAverage.Add("Blocks", stats.Average(stat => stat.Blocks));
            statsAverage.Add("Assists", stats.Average(stat => stat.Assists));
            statsAverage.Add("Rebounds", stats.Average(stat => stat.TotalRebounds));
            statsAverage.Add("Steals", stats.Average(stat => stat.Steals));

            return Json(statsAverage);
        }
    }
}
