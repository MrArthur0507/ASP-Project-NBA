using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DbModels
{
    public class Game
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int HomeTeamScore { get; set; }

        public int VisitorTeamSccore { get; set; }


        public Team HomeTeam { get; set; }

        public Team VisitorTeam { get; set; }

        public Team WinningTeam { get; set; }
    }
}
