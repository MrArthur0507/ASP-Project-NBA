using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ExtendedUserViewModel
    {
        public UserViewModel User { get; set; }

        public List<ReviewViewModel> Comments { get; set; } 
    }
}
