using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Models.DbModels;
using NBAProject.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PlayerCrudOperations : IPlayerCrudOperations
    {
        private readonly ApplicationDbContext _context;
        public PlayerCrudOperations(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<List<Player>> GetAll()
        {
            List<Player> players = await _context.Players.ToListAsync();

            return players;
        }

        public async Task<Player> GetById(int id)
        {
            Player player = await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == id);
            return player;
        }

        public async Task Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
