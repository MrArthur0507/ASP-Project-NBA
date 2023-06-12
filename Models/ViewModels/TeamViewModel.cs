using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class TeamViewModel
    {
            public int Id { get; set; }
            public string? Abbreviation { get; set; }
            public string? City { get; set; }
            public string? Conference { get; set; }
            public string? Division { get; set; }
            public string? Fullname { get; set; }
            public string? Name { get; set; }
            

    }
}
