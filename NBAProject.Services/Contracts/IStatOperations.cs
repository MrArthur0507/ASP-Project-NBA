using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IStatOperations
    {
        public Task<GameStatViewModel> GetStatsByGameId(int id);

        public Task<Dictionary<string, double?>> GetBasicStatsByPlayerId(int id);

        public Task<StatGameTotalViewModel> GetTotalForGame(int id);
    }
}
