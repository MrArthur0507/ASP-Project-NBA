using Models.DbModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPlayerCrudOperations
    {
        public List<PlayerViewModel> GetAll();

        public PlayerDetailsViewModel GetById(int id);

        public Task Update(int id);

        public Task Delete(int id);
    }
}
