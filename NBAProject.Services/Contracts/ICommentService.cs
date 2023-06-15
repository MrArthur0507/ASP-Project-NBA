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
        Task AddComment(CommentViewModel comment, int gameId);
        Task<List<CommentViewModel>> GetCommentsByGameId(int gameId);
        Task<CommentViewModel> GetCommentById(int commentId);
        Task DeleteComment(int commentId);
    }
}
