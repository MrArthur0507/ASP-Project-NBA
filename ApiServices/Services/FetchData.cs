using ApiServices.Contracts;
using Models.DbModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services
{
    public class FetchData : IFetchData
    {
        private readonly IFetchPlayer _fetchPlayer;

        private readonly IFetchGame _fetchGame;

        private readonly IFetchStat _fetchStat;

        private readonly ApplicationDbContext _context;
        public FetchData(IFetchPlayer fetchPlayer, IFetchGame fetchGame, IFetchStat fetchStat, ApplicationDbContext context) {
            _fetchPlayer = fetchPlayer;
            _fetchGame = fetchGame;
            _fetchStat = fetchStat;
            _context = context;
        }

        

        public async Task Fetch()
        {
            
            await _fetchPlayer.FetchPlayersWithDelay();
            await _fetchGame.FetchGames();
            await _fetchStat.FetchStats();
              
        }

       

    }
}
