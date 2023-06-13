using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using ProjectData.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.CrudRelated
{
    public class CommentOperations : ICommentOperations
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentOperations(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public CreateCommentViewModel GetViewModel()
        {
            return new CreateCommentViewModel();
        }
        public async Task CreateComment(string content, int gameId)
        {

            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            var comment = new Comment
            {
                Content = content,
                Date = DateTime.Now,
                UserId = userId,
                GameId = gameId,

            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public async Task<List<CommentViewModel>> GetCommentsByGameId(int gameId)
        {
            return await _context.Comments
                .Where(c => c.GameId == gameId)
                .Select(c => new CommentViewModel
                {
                    
                    Content = c.Content,
                    
                    
                })
                .ToListAsync();
        }
    }
}
