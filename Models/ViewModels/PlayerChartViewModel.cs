using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PlayerChartViewModel
    {
        public double? AveragePoints { get; set; }

        public double? AverageAssists { get; set; }

        public double? AverageBlocks { get; set; }

        public double? AverageRebounds { get; set; }

        public Dictionary<string, double> stats = new Dictionary<string, double>();
    }
}
