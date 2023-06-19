using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICommentService
    {
        Task AddComment(ReviewViewModel comment, int gameId);
        Task<List<ReviewViewModel>> GetCommentsByGameId(int gameId);
        Task<ReviewViewModel> GetCommentById(int commentId);
        Task DeleteComment(int commentId);
    }
}
