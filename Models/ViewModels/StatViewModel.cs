using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class StatViewModel
    {
        public int? Assists { get; set; }
        public int? Blocks { get; set; }
        public int? DefensiveRebounds { get; set; }
        public double? ThreePointFieldGoalPercentage { get; set; }
        public int? ThreePointFieldGoalsAttempted { get; set; }
        public int? ThreePointFieldGoalsMade { get; set; }
        public double? FieldGoalPercentage { get; set; }
        public int? FieldGoalsAttempted { get; set; }
        public int? FieldGoalsMade { get; set; }
        public double? FreeThrowPercentage { get; set; }
        public int? FreeThrowsAttempted { get; set; }
        public int? FreeThrowsMade { get; set; }

        public string? Minutes { get; set; }
        public int? OffensiveRebounds { get; set; }
        public int? PersonalFouls { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int? Points { get; set; }
        public int? TotalRebounds { get; set; }
        public int? Steals { get; set; }

        public int? Turnovers { get; set; }
    }
}
