using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using Services.Services;

namespace NBAProject.Controllers
{
    public class GameController : Controller
    {


        private readonly IGameService _gameService;

        private readonly IStatService _statService;
        public GameController(IStatService statService, IGameService gameService)
        {
            _statService = statService;
            _gameService = gameService;
        }
        public IActionResult Index()
        {
            SelectTeamViewModel model = _gameService.GetSelect();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SelectTeamViewModel select)
        {
            List<GameViewModel> games = _gameService.GetGames(select.HomeTeamId, select.VisitorTeamId);

            return View(games);
        }

        public async Task<IActionResult> Details(int id)
        {
            GameStatViewModel viewModel = await _statService.GetStatsByGameId(id);
            return View(viewModel);
        }

        public async Task<IActionResult> PlayerStatForGame(int gameId, int playerId)
        {
            
            return View(new StatViewModel() { GameId = gameId, PlayerId = playerId});
        }

    }
}
