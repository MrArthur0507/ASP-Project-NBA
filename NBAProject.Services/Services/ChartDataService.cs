using AutoMapper;
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

        private readonly IMapper _mapper;
		public ChartDataService(ApplicationDbContext context, IMapper mapper)
		{
			_context= context;
            _mapper = mapper;
		}

        public async Task<List<TeamSeasonAverageViewModel>> GetGames(int teamId)
        {
            IQueryable<Game> games = _context.Games.AsQueryable();

            var result = games
           .Where(g => g.HomeTeamId == teamId || g.VisitorTeamId == teamId).ToList();
            var grouped = result
           .GroupBy(g => g.Season)
           .Select(g => new TeamSeasonAverageViewModel
           {
               Season = g.Key,
               AverageScoreWhenAway = (g.Where(g => g.VisitorTeamId == teamId)).Average(g => g.VisitorTeamScore),
               AverageScoreWhenHome = (g.Where(g => g.HomeTeamId == teamId)).Average(g => g.HomeTeamScore),
           });

            var sortedAverages = grouped.OrderBy(sorted => sorted.Season).ToList();

            return sortedAverages.ToList();
        }


        public List<PlayerViewModel> GetPlayers(int teamId)
        {
            List<PlayerViewModel> players = _context.Players.Where(player => player.TeamId == teamId)
            .Select(player => _mapper.Map<PlayerViewModel>(player)).ToList();


            return players;
            
        }
    }
}
