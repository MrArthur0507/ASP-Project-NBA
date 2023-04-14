using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.ViewModels
{
    public class PlayerViewModel : BasicViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public int HeightFeet { get; set; }

        public int HeightInches { get; set; }

        public int WeightPounds { get; set; }

        public string TeamFullName { get; set; }
    }
}
