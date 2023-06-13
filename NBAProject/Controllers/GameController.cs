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

        private readonly IGameCrudOperations _gameCrud;

        private readonly IStatOperations _statOperations;
        public GameController(IGameCrudOperations gameCrud, IStatOperations statOperations)
        {
            _gameCrud = gameCrud;
            _statOperations = statOperations;
        }
        public IActionResult Index()
        {
            SelectTeamViewModel model = _gameCrud.GetSelect();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SelectTeamViewModel select)
        {
            List<GameViewModel> games = _gameCrud.GetGames(select.HomeTeamId, select.VisitorTeamId);

            return View(games);
        }

        public async Task<IActionResult> Details(int id)
        {
            
            return View(await _statOperations.GetStatsByGameId(id));
        }

    }
}
