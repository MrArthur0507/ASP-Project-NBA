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
        private readonly ICommentOperations _commentOperations;

        public CommentController(ICommentOperations commentOperations)
        {
            _commentOperations = commentOperations;
        }

        public IActionResult Create()
        {

            return View(new CreateCommentViewModel());
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateComment(string comment, int gameId)
        {
            if (ModelState.IsValid)
            {
                _commentOperations.CreateComment(comment, gameId);

                

                return RedirectToAction("Details", "Game");
            }
            return View();
        }

        //public async IActionResult GetByGame(int gameId)
        //{
            
        //    return View(await _commentOperations.GetCommentsByGameId(gameId));
        //}
    }
}
