using ApiServices.Contracts;
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

        public bool PlayersAndTeamsFetchCompleted { get; set; }

        public bool GamesFetchCompleted { get; set; }

        public async Task FetchPlayersAndTeams()
        {
            await _fetchPlayer.FetchPlayersWithDelay(_context);
        }

        public async Task FetchGames()
        {
            await _fetchGame.FetchGames(_context);
        }

        public async Task FetchStats()
        {
            await _fetchStat.FetchStats();
        }

    }
}
