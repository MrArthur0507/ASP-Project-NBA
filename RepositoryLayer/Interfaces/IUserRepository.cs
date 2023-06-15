using ProjectData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> GetUserById(string userId);
        Task<ApplicationUser> GetUserByUsername(string username);
    }

}
