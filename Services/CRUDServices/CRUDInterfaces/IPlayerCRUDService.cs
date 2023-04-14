using ModelsLibrary.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CRUDServices.CRUDInterfaces
{
    public interface IPlayerCRUDService
    {
        IEnumerable<PlayerViewModel> GetAllPlayers();

        PlayerViewModel GetPlayerById(string id);

        void CreatePlayer(PlayerViewModel player);

        void UpdatePlayer(PlayerViewModel player);

        void DeletePlayer(PlayerViewModel player);
    }
}
