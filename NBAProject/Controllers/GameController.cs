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

        private readonly ApplicationDbContext _context;
        public GameController(IGameCrudOperations gameCrud, ApplicationDbContext context)
        {
            _gameCrud = gameCrud;
            _context = context;
        }
        public IActionResult Index()
        {
            SelectTeamViewModel model = _gameCrud.GetSelect();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SelectTeamViewModel select)
        {
            List<Game> games = _gameCrud.GetGames(select.HomeTeamId, select.VisitorTeamId);

            return View(games);
        }


    }
}
