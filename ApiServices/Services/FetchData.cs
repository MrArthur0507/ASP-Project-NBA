using ApiServices.Contracts;
using Microsoft.Extensions.Logging;
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

            if(!CheckForStarting())
            {
                await _fetchPlayer.FetchPlayersWithDelay();
                await _fetchGame.FetchGames();
                await _fetchStat.FetchStats();
                
            }
            
        }

       
        private bool CheckForStarting()
        {
            ApiLogger logger = _context.ApiLogger.OrderBy(log => log.Date).LastOrDefault();
            if (logger == null || (logger.Date - DateTime.Now).Hours > 12)
            {
                Console.WriteLine("Log null");
                AddLog();
                return false;
            }

            return true;
        }

        private void AddLog()
        {
            ApiLogger logger = new ApiLogger()
            {
                Date = DateTime.Now,
                isFinished = false,
                Type = "Manual",
            };
            _context.ApiLogger.Add(logger);
            _context.SaveChanges();
        }

        public List<ApiLogger> GetLog()
        {
            return _context.ApiLogger.ToList();
        }
       
    }
}
