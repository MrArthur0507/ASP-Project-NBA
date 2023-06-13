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

namespace Services.Services.CrudRelated
{
    public class StatOperations : IStatOperations
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StatOperations(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GameStatViewModel> GetStatsByGameId(int id)
        {
            IQueryable<Stat> stats = _context.Stats.Where(x => x.GameId == id).Include(stat => stat.Player);

            

            List<Stat> statsResult = await stats.ToListAsync();
            GameStatViewModel result = new GameStatViewModel() { GameId = id };
            result.Stats = (statsResult.Select(stat => _mapper.Map<PlayerViewModel>(stat.Player))).ToList();


            return result;

        }

        public async Task<Dictionary<string, double?>> GetBasicStatsByPlayerId(int id)
        {
            List<Stat> stats = _context.Stats.Where(stats => stats.PlayerId == id).ToList();
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
           List<Stat> stats = await _context.Stats.Where(stat => stat.GameId == id).ToListAsync();

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
    }
}
