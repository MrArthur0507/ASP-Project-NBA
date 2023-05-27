using Models.ApiModels;
using Models.DbModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Contracts
{
    public interface IStatSeeder
    {
        public List<Stat> Seed(StatRoot input, ApplicationDbContext context, List<Stat> stats);
    }
}
