using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class FreeThrowsViewModel
    {
        public double? FreeThrowPercentage { get; set; }
        public int? FreeThrowsAttempted { get; set; }
        public int? FreeThrowsMade { get; set; }
    }
}
