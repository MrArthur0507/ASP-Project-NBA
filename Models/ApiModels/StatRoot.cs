using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiModels
{
    public class StatRoot
    {
        public List<StatApi> Data { get; set; }

        public MetaApi Meta { get; set; }
    }
}
