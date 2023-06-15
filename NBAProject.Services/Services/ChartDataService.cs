using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using RepositoryLayer.Interfaces;
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
        private readonly IGameRepository _gameRepository;

        private readonly IMapper _mapper;
		public ChartDataService(IGameRepository gameRepository, IMapper mapper)
		{
            _gameRepository = gameRepository;
            _mapper = mapper;
		}

        public async Task<List<TeamSeasonAverageViewModel>> GetGames(int teamId)
        {
            var games = await _gameRepository.GetGamesByTeamId(teamId);

            var grouped = games
                .GroupBy(g => g.Season)
                .ToList();

            var finalResult = grouped
                .Select(g => new TeamSeasonAverageViewModel
                {
                    Season = g.Key,
                    AverageScoreWhenAway = g.Where(g => g.VisitorTeamId == teamId).Average(g => g.VisitorTeamScore),
                    AverageScoreWhenHome = g.Where(g => g.HomeTeamId == teamId).Average(g => g.HomeTeamScore),
                })
                .OrderBy(g => g.Season)
                .ToList();

            return finalResult;
        }


    }
}
