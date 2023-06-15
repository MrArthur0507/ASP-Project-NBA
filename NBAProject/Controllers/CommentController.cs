using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using System.Security.Claims;

namespace NBAProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Create()
        {

            return View(new CommentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel comment, int gameId)
        {
            if (ModelState.IsValid)
            {
               await _commentService.AddComment(comment, gameId);
            }
            return Ok();
        }
    }
}
