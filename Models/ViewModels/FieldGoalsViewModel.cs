using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class FieldGoalsViewModel
    {
        public double? ThreePointFieldGoalPercentage { get; set; }
        public int? ThreePointFieldGoalsAttempted { get; set; }
        public int? ThreePointFieldGoalsMade { get; set; }
        public double? FieldGoalPercentage { get; set; }
        public int? FieldGoalsAttempted { get; set; }
        public int? FieldGoalsMade { get; set; }
    }
}
