using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using NBAProject.Data;
using ProjectData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllForGameId(int gameId)
        {
            return await _context.Reviews
            .Where(c => c.GameId == gameId)
            .ToListAsync();
        }

        public async Task<List<Review>> GetByUserId(string userId)
        {
            return await _context.Reviews.Where(review => review.UserId == userId).ToListAsync();
        }
    }
}
