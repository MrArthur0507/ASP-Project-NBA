using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;

namespace NBAProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamCrudOperations _teamOperations;

        private readonly IChartDataService _chartService;
        private readonly ApplicationDbContext _context;

        public TeamController(IChartDataService chartService, ITeamCrudOperations teamOperations, ApplicationDbContext context) { 
            _teamOperations = teamOperations;
            _chartService = chartService;
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View(_teamOperations.GetAll());
        }

        public IActionResult Details(int id)
        {
            TeamViewModel team = _teamOperations.GetById(id);
            return View(team);
        }


        public async  Task<IActionResult> GetAverageScores(int teamId)
        {
            List<TeamSeasonAverageViewModel> average = await _chartService.GetGames(teamId);
            return Json(average);
        }


        public async Task<IActionResult> GetPlayerInTeam(int teamId)
        {
            List<PlayerViewModel> players = _chartService.GetPlayers(teamId);
            return Json(players);
        }
    }
}
