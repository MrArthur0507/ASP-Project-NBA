using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiModels
{
    public class GameRoot
    {
        public List<GameApi> Data { get; set; }

        public MetaApi Meta { get; set; }
    }
}
