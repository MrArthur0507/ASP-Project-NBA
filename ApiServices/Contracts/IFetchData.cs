using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Contracts
{
    public interface IFetchData
    {
        public bool PlayersAndTeamsFetchCompleted { get; set; }

        public bool GamesFetchCompleted { get; set; }

        public Task FetchPlayersAndTeams();

        public Task FetchGames();

        public Task FetchStats();

        
    }
}
