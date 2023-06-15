using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using Services.Services;

namespace NBAProject.Controllers
{
    public class PlayerController : Controller
    {

        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public  IActionResult Index(int page)
        {
            return View(_playerService.GetPlayersByPage(page));
        }

        public async Task<IActionResult> Details(int id)
        {
            PlayerDetailsViewModel player = await _playerService.GetPlayerById(id);
            return View(player);
        }

        //public async Task<IActionResult> Create()
        //{
            
        //    return View(await _playerService());
        //}
        
        public IActionResult Search(string param)
        {
            
            return View(_playerService.SearchPlayers(param));
        }
        
    }
}
