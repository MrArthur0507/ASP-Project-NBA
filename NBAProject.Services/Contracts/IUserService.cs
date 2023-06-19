using Models.ViewModels;
using ProjectData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetAllUsers();
        public Task<UserViewModel> GetUserById(string userId);
        public Task<UserViewModel> GetUserByUsername(string userId);
        string GetUserId();
        bool IsUserAuthenticated();

    }
}
