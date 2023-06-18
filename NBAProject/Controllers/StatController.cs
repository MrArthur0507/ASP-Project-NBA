using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using Services.Contracts;
using Services.Services;

namespace NBAProject.Controllers
{
    public class StatController : Controller
    {
        private readonly IStatService _statService;
        public StatController(IStatService statService) {
            _statService = statService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetBasicStatsByPlayerId(int id)
        {

            return Json(await _statService.GetBasicStatsByPlayerId(id));
        }

        public async Task<IActionResult> GetTotalForGame(int id)
        {
            StatGameTotalViewModel total =  await _statService.GetTotalForGame(id);
           
            return Json(total.GameTotal);
        }

        public async Task<IActionResult> PlayerStatForGame(int gameId, int playerId)
        {
            StatViewModel statViewModel = await _statService.GetStatsByGameIdAndPlayerId(gameId, playerId);
            return Json(statViewModel);
        }

        public async Task<IActionResult> GetPlayerStatForGame(int gameId, int playerId)
        {
            StatViewModel statViewModel = await _statService.GetStatsByGameIdAndPlayerId(gameId, playerId);
            return Json(statViewModel);
        }
    }
}
