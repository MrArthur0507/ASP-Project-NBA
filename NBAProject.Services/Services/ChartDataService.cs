using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
	public class ChartDataService : IChartDataService
	{
		private readonly ApplicationDbContext _context;
		public ChartDataService(ApplicationDbContext context)
		{
			_context= context;
			
		}

        public async Task<List<TeamSeasonAverageViewModel>> GetGames(int teamId)
        {
            IQueryable<Game> games = _context.Games.AsQueryable();

            var seasonAverages = games
           .Where(g => g.HomeTeamId == teamId || g.VisitorTeamId == teamId)
           .GroupBy(g => g.Season)
           .Select(g => new TeamSeasonAverageViewModel
           {
               Season = g.Key,
               AverageScoreWhenAway = (g.Where(g => g.VisitorTeamId == teamId)).Average(g => g.VisitorTeamScore),
               AverageScoreWhenHome = (g.Where(g => g.HomeTeamId == teamId)).Average(g => g.HomeTeamScore),
           });

            var sortedAverages = seasonAverages.OrderBy(sorted => sorted.Season);

            return sortedAverages.ToList();
        }
    }
}
