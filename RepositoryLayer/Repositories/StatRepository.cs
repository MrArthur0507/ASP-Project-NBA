using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using NBAProject.Data;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class StatRepository : IStatRepository
    {
        private readonly ApplicationDbContext _context;

        public StatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stat>> GetStatsByGameId(int id)
        {
            return await _context.Stats
                .Where(stat => stat.GameId == id)
                .Include(stat => stat.Player).ToListAsync();
        }

        public async Task<List<Stat>> GetStatsByPlayerId(int id)
        {
            return await _context.Stats
                .Where(stat => stat.PlayerId == id)
                .ToListAsync();
        }

        public async Task<List<Stat>> GetTotalPointsByGameId(int id)
        {
            return await _context.Stats
                .Where(stat => stat.GameId == id).ToListAsync();
        }

        public async Task<Stat> GetStatByGameIdAndPlayerId(int gameId, int playerId)
        {
            return await _context.Stats
                .FirstOrDefaultAsync(stat => stat.GameId == gameId && stat.PlayerId == playerId);
        }


        //public List<PlayerStatsSummary> GetTopPlayersByPoints(int count)
        //{
        //    var query = from stats in _context.Stats
        //                join player in _context.Players on stats.PlayerId equals player.Id
        //                group stats by new { stats.PlayerId, player.FirstName } into g
        //                orderby g.Sum(stats => stats.Points) descending
        //                select new PlayerStatsSummary
        //                {
        //                    PlayerId = g.Key.PlayerId,
        //                    TotalPoints = g.Sum(stats => stats.Points),
        //                    FirstName = g.Key.FirstName
        //                };

        //    return query.Take(count).ToList();
        //}
    }
}
