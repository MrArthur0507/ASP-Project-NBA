using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiModels
{
    public class GameApi
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public TeamApi home_team { get; set; }
        public int home_team_score { get; set; }
        public int period { get; set; }
        public bool postseason { get; set; }
        public int season { get; set; }
        public string status { get; set; }
        public string time { get; set; }
        public TeamApi visitor_team { get; set; }
        public int visitor_team_score { get; set; }
    }
}
