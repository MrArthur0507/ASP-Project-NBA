using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> GetAllTeams();
        Team GetTeamById(int teamId);
    }
}
