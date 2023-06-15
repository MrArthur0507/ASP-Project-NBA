using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using Services.Services;

namespace NBAProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IChartDataService _chartService;
        private readonly ITeamService _teamService;

        public TeamController(IChartDataService chartService, IPlayerService playerService, ITeamService teamService) {
            _playerService = playerService;
            _chartService = chartService;
            _teamService = teamService;
        }
        public IActionResult Index()
        {
            
            return View(_teamService.GetAllTeams());
        }

        public IActionResult Details(int id)
        {
            TeamViewModel team = _teamService.GetTeamById(id);
            return View(team);
        }


        public async  Task<IActionResult> GetAverageScores(int teamId)
        {
            List<TeamSeasonAverageViewModel> average = await _chartService.GetGames(teamId);
            return Json(average);
        }


        public async Task<IActionResult> GetPlayerInTeam(int teamId)
        {
            List<PlayerViewModel> players = _playerService.GetPlayersByTeam(teamId);
            return Json(players);
        }
    }
}
