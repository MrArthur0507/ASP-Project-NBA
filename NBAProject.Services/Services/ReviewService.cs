using AutoMapper;
using DataAccessLayer.Interfaces;
using Models.ViewModels;
using ProjectData.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IUserService userService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public ReviewViewModel GetReviewForm() {
            ReviewViewModel reviewViewModel = new ReviewViewModel()
            {
                UserId = _userService.GetUserId(),
            };
            return reviewViewModel;
        }

        public async Task AddReview(CreateReviewViewModel review)
        {
            Review gameReview = _mapper.Map<Review>(review);
            gameReview.UserId = _userService.GetUserId();
            gameReview.Id = Guid.NewGuid().ToString();
            gameReview.CreatedAt = DateTime.Now;
            await _reviewRepository.AddReview(gameReview);
        }

        public async Task<List<ReviewViewModel>> GetReviewByGameId(int gameId)
        {
            List<Review> reviews = await _reviewRepository.GetAllForGameId(gameId);
            List<ReviewViewModel> reviewViewModels = reviews.Select(review => _mapper.Map<ReviewViewModel>(review)).ToList();
            return reviewViewModels;
        }
    }
}
