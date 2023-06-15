using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetGames(int visitorTeamId, int homeTeamId);

        public Task<List<Game>> GetGamesByTeamId(int teamId);
    }
}
