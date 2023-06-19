using ProjectData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReviewRepository
    {
        public Task<List<Review>> GetAllForGameId(int gameId);
        public Task AddReview(Review comment);
    }
}
