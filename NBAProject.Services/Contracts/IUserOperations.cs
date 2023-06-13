using Microsoft.AspNetCore.Identity;
using ProjectData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserOperations
    {
        public Task<ApplicationUser> GetUserDetails(string userId);

        public Task<IdentityResult> DeleteUser(string userId);
    }
}
