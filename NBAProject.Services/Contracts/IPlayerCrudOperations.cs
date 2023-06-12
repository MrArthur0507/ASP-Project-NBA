using Models.DbModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Services.Contracts
{
    public interface IPlayerCrudOperations
    {

        public IPagedList<PlayerViewModel> GetByPage(int page);
        public Task<PlayerDetailsViewModel> GetById(int id);

        public  Task<CreatePlayerViewModel> Create();
        public Task Update(PlayerViewModel playerViewModel);

        public Task Delete(int id);
    }
}
