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
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public Team GetTeamById(int teamId)
        {
            return _context.Teams.FirstOrDefault(x => x.Id == teamId);
        }
    }
}
