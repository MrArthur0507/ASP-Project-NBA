using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int Period { get; set; }
        public bool PostSeason { get; set; }
        public int Season { get; set; }
        public string Status { get; set; }
        public string? Time { get; set; }

        public int VisitorTeamId { get; set; }
        public Team VisitorTeam { get; set; }
        public int VisitorTeamScore { get; set; }

        
    }
}
