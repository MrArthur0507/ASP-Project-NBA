using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IChartDataService
    {
        public Task<List<TeamSeasonAverageViewModel>> GetGames(int teamId);

        public List<PlayerViewModel> GetPlayers(int teamId);
    }
}
