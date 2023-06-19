using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using ProjectData.Data;
using ServiceLayer.Services;
using Services.Contracts;

namespace NBAProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;

        public UserController(IUserService userService, IReviewService reviewService)
        {
            _userService= userService;
            _reviewService = reviewService;
        }

        
        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await _userService.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            ExtendedUserViewModel extendedUserViewModel = await _reviewService.GetReviewsForPlayer(id);
            return View(extendedUserViewModel);
        }

    }
}
