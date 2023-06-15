using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IStatRepository
    {
        public Task<List<Stat>> GetStatsByGameId(int id);
        public Task<List<Stat>> GetStatsByPlayerId(int id);
        public Task<List<Stat>> GetTotalPointsByGameId(int id);
        public Task<Stat> GetStatByGameIdAndPlayerId(int gameId, int playerId);
    }
}
