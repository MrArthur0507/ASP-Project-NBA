using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectData.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.CrudRelated
{
    public class UserOperations : IUserOperations
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserOperations(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<ApplicationUser> GetUserDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }


        public async Task<IdentityResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result;
            }

            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        public async Task<List<ApplicationUser>> SearchUsersByName(string searchTerm)
        {
            return await _userManager.Users
                .Where(u => u.UserName.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
