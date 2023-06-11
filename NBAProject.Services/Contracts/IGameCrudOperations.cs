using Models.DbModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGameCrudOperations
    {
        public List<Game> GetGames(int homeId, int visitorId);

        public SelectTeamViewModel GetSelect();
    }
}
