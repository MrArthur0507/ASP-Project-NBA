using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiModels
{
    public class StatApi
    {
        public int id { get; set; }
        public int? ast { get; set; }
        public int? blk { get; set; }
        public int? dreb { get; set; }
        public double? fg3_pct { get; set; }
        public int? fg3a { get; set; }
        public int? fg3m { get; set; }
        public double? fg_pct { get; set; }
        public int? fga { get; set; }
        public int? fgm { get; set; }
        public double? ft_pct { get; set; }
        public int? fta { get; set; }
        public int? ftm { get; set; }
        public GameApi game { get; set; }
        public string? min { get; set; }
        public int? oreb { get; set; }
        public int? pf { get; set; }
        public PlayerApi player { get; set; }
        public int? pts { get; set; }
        public int? reb { get; set; }
        public int? stl { get; set; }
        public TeamApi team { get; set; }
        public int? turnover { get; set; }
    }
}
