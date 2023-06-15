using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace RepositoryLayer.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Task<Player> GetById(int id);
        IEnumerable<Player> SearchPlayers(string searchTerm);

        List<Player> GetPlayersByTeamId(int teamId);
    }
}
