using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }

        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}
