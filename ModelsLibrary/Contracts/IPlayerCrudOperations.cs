using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPlayerCrudOperations
    {
        public Task<List<Player>> GetAll();

        public Task<Player> GetById(int id);

        public Task Update(int id);

        public Task Delete(int id);
    }
}
