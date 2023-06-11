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
            PlayerDetailsViewModel player = _playerService.GetById(id);
            return View(player);
        }

        public async Task<IActionResult> GetStats(int id)
        {
            List<Stat> stats = _context.Stats.Where(stats => stats.PlayerId == id).ToList();

            return Json(stats);
        }
    }
}
