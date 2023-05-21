using ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.ApiModels;
using Models.DbModels;
using Newtonsoft.Json;

namespace NBAProject.Controllers
{
    public class ApiController : Controller
    {
        private readonly IFetchPlayer _fetchPlayer;
        private readonly IFetchGame _fetchGame;
        public ApiController(IFetchPlayer fetchPlayer, IFetchGame fetchGame) {
            _fetchPlayer = fetchPlayer;
            _fetchGame = fetchGame;
        }
        public async Task Index()
        {
            await _fetchGame.FetchGames();
        }
    }
}
