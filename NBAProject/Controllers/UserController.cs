using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using ProjectData.Data;
using Services.Contracts;
using Services.Services.CrudRelated;

namespace NBAProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService= userService;
        }

        
        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await _userService.GetAllUsers();
            return View(users);
        }

      

    }
}
