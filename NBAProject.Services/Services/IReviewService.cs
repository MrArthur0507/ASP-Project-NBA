using Models.ViewModels;
using ProjectData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IReviewService
    {
        public Task AddReview(CreateReviewViewModel review);

        public Task<List<ReviewViewModel>> GetReviewByGameId(int gameId);

        public ReviewViewModel GetReviewForm();

        public Task<ExtendedUserViewModel> GetReviewsForPlayer(string userId);
    }
}
