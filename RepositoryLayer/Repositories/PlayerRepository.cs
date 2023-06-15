using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using NBAProject.Data;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace RepositoryLayer.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetAll()
        {

            return _context.Players.ToList();
        }

        public async Task<Player> GetById(int id)
        {
            return await _context.Players
                .Include(player => player.Team)
                .FirstOrDefaultAsync(player => player.Id == id);
        }


        public IEnumerable<Player> SearchPlayers(string searchTerm)
        {
            return _context.Players
                .Where(player => player.FirstName.Contains(searchTerm) || player.LastName.Contains(searchTerm) || (player.FirstName + player.LastName).Contains(searchTerm))
                .ToList();
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _context.Players
                .Where(player => player.TeamId == teamId)
                .ToList();
        }
    }
}
