using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class Meta
    {
        public string Id { get; set; }

        public int TotalPages { get; set; }
        public int? CurrentPage { get; set; }
        public int? NextPage { get; set; }
        
        public int? PerPage { get; set; }
        public int? TotalCount { get; set; }

    }
}
