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
        public ApiController(IFetchPlayer fetchPlayer) {
            _fetchPlayer = fetchPlayer;
        
        }
        public async Task Index()
        {
            await _fetchPlayer.FetchPlayersWithDelay();
        }
    }
}
