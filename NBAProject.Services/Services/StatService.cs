using AutoMapper;
using Models.DbModels;
using Models.ViewModels;
using RepositoryLayer.Interfaces;
using ServiceLayer.Services;
using Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StatService : IStatService
    {
        private readonly IStatRepository _statRepository;
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;

        public StatService(IStatRepository statRepository, IMapper mapper, IReviewService reviewService)
        {
            _statRepository = statRepository;
            _mapper = mapper;
            _reviewService = reviewService;
        }

        public async Task<GameStatViewModel> GetStatsByGameId(int id)
        {
            List<Stat> stats = await _statRepository.GetStatsByGameId(id);

            GameStatViewModel result = new GameStatViewModel() {
                GameId = id,
                Stats = stats.Select(stat => _mapper.Map<PlayerViewModel>(stat.Player)).ToList(),
                Reviews = await _reviewService.GetReviewByGameId(id),
            };
            result.Form = new CreateReviewViewModel() { GameId = id };
           
            return result;
        }

        public async Task<Dictionary<string, double?>> GetBasicStatsByPlayerId(int id)
        {
            List<Stat> stats = await _statRepository.GetStatsByPlayerId(id);

            Dictionary<string, double?> statsAverage = new Dictionary<string, double?>();

            statsAverage.Add("Points", stats.Average(stat => stat.Points));
            statsAverage.Add("Blocks", stats.Average(stat => stat.Blocks));
            statsAverage.Add("Assists", stats.Average(stat => stat.Assists));
            statsAverage.Add("Rebounds", stats.Average(stat => stat.TotalRebounds));
            statsAverage.Add("Steals", stats.Average(stat => stat.Steals));

            return statsAverage;
        }

        public async Task<StatGameTotalViewModel> GetTotalForGame(int id)
        {
            List<Stat> stats = await _statRepository.GetStatsByGameId(id);

            Dictionary<string, int?> total = new Dictionary<string, int?>();

            total.Add("Points", stats.Sum(stat => stat.Points));
            total.Add("Assists", stats.Sum(stat => stat.Assists));
            total.Add("Blocks", stats.Sum(stat => stat.Blocks));
            total.Add("Steals", stats.Sum(stat => stat.Steals));
            total.Add("Rebounds", stats.Sum(stat => stat.TotalRebounds));
            total.Add("Fouls", stats.Sum(stat => stat.PersonalFouls));

            StatGameTotalViewModel result = new StatGameTotalViewModel()
            {
                GameTotal = total,
            };
            return result;
        }

        public async Task<StatViewModel> GetStatsByGameIdAndPlayerId(int gameId, int playerId)
        {
            var stats = await _statRepository.GetStatByGameIdAndPlayerId(gameId, playerId);
            StatViewModel statViewModel = _mapper.Map<StatViewModel>(stats);
            return statViewModel;
        }
    }
}
