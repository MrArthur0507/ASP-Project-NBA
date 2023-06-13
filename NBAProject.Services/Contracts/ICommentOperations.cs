using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICommentOperations
    {
        public CreateCommentViewModel GetViewModel();
        public Task CreateComment(string content, int gameId);

        public  Task<List<CommentViewModel>> GetCommentsByGameId(int gameId);


    }
}
