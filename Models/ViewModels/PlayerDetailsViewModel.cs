﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? HeightFeet { get; set; }
        public int? HeightInches { get; set; }
        public string LastName { get; set; }
        public string? Position { get; set; }
        public int? WeightPounds { get; set; }
        public string TeamName { get; set; }
        public string? TeamFullname { get; set; }
        public string? TeamAbbreviation { get; set; }

    }
}
