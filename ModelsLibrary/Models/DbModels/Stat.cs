using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DbModels
{
    public class Stat
    {      
        
        public string GameId { get; set; }
        public Game Game { get; set; }
        public string PlayerId { get; set; }
        public Player Player { get; set; }

        public int? Points { get; set; }

        public int? Assists { get; set; }

        public int? Rebounds { get; set; }

        public int? Steals { get; set; }

        public int? Blocks { get; set; }
    
    }
}
