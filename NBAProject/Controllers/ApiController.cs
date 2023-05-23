using ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.ApiModels;
using Models.DbModels;
using Newtonsoft.Json;

namespace NBAProject.Controllers
{
    public class ApiController : Controller
    {
        private readonly IFetchData _fetchData;
        public ApiController(IFetchData fetchData) {
            _fetchData = fetchData;
        }
        public async Task Index()
        {
            await _fetchData.FetchPlayersAndTeams();
        }
    }
}
