using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectData.Data;
using Services.Contracts;
using Services.Services.CrudRelated;

namespace NBAProject.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserOperations _userOperations;

        public UserController(UserManager<ApplicationUser> userManager, IUserOperations userOperations)
        {
            _userManager = userManager;
            _userOperations = userOperations;
        }

        
        public IActionResult Index()
        {
            List<ApplicationUser> users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(string userId)
        {
            var user = await _userOperations.GetUserDetails(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await _userOperations.DeleteUser(userId);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return BadRequest(result.Errors);
        }

    }
}
