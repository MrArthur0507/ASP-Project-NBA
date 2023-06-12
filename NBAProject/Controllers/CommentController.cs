using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using System.Security.Claims;

namespace NBAProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CommentController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public  IActionResult Create()
        {
            
            return View(new CreateCommentViewModel());
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateComment(int id, CreateCommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var comment = new Comment
                {
                    Content = commentViewModel.Content,
                    Date = DateTime.Now,
                    UserId = userId,
                    
                };

                _context.Comments.Add(comment);
                _context.SaveChanges();

                return RedirectToAction("Details", "Game"); 
            }
            return View();
        }
    }
}
