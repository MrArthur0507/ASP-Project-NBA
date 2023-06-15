using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IGameService
    {
        SelectTeamViewModel GetSelect();
        List<GameViewModel> GetGames(int visitorTeamId, int homeTeamId);
    }
}
