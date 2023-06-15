using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICommentRepository 
    {
        Task AddComment(Comment comment);
        Task<List<Comment>> GetCommentsByGameId(int gameId);
        Task<Comment> GetCommentById(int commentId);
        Task DeleteComment(int commentId);
    }
}
