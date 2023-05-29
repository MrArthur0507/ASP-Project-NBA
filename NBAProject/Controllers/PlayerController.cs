using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Contracts;

namespace NBAProject.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerCrudOperations _playerService;

        public PlayerController(IPlayerCrudOperations playerCrudOperations)
        {
            _playerService= playerCrudOperations;
        }
        public  IActionResult Index()
        {
            
            return View(_playerService.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            PlayerDetailsViewModel player = _playerService.GetById(id);
            return View(player);
        }
    }
}
