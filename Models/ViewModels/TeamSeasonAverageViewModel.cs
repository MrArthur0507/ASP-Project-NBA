using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
	public class TeamSeasonAverageViewModel
	{
		public int Season { get; set; }

		public double AverageScoreWhenHome { get; set; }

		public double AverageScoreWhenAway { get; set; }
	}
}
