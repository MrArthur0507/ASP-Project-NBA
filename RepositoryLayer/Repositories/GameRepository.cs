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
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Game> GetGames(int visitorTeamId, int homeTeamId)
        {
            return _context.Games
                .Where(g => g.VisitorTeamId == visitorTeamId && g.HomeTeamId == homeTeamId)
                .ToList();
        }

        public async Task<List<Game>> GetGamesByTeamId(int teamId)
        {
            return await _context.Games
                .Where(g => g.HomeTeamId == teamId || g.VisitorTeamId == teamId)
                .ToListAsync();
        }

    }
}
