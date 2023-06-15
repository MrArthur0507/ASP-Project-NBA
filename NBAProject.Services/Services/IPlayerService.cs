using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Services.Services
{
    public interface IPlayerService
    {
        IPagedList<PlayerViewModel> GetPlayersByPage(int page);
        Task<PlayerDetailsViewModel> GetPlayerById(int id);
        //Task<CreatePlayerViewModel> GetCreatePlayerViewModel();
        //Task UpdatePlayer(PlayerViewModel playerViewModel);
        List<PlayerViewModel> SearchPlayers(string searchTerm);
        List<PlayerViewModel> GetPlayersByTeam(int teamId);
    }
}
