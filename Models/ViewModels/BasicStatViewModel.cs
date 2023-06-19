using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class BasicStatViewModel
    {
        public int? Points { get; set; }
        public int? TotalRebounds { get; set; }
        public int? Steals { get; set; }
        public int? Assists { get; set; }
        public int? Blocks { get; set; }

        public int? DefensiveRebounds { get; set; }

        public int? OffensiveRebounds { get; set; }
        public int? PersonalFouls { get; set; }
    }
}
