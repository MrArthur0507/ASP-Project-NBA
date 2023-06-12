using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class SelectTeamViewModel
    {
        public int HomeTeamId { get; set; }

        public int VisitorTeamId { get; set; }

        public string Season { get; set; }
        public List<SelectListItem> SelectedTeam { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> SelectedSeason { get; set; } = new List<SelectListItem>();
    }
}
