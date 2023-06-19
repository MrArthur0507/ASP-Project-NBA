using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using ServiceLayer.Services;
using Services.Contracts;

namespace ApplicationLayer.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReview(CreateReviewViewModel model)
        {

                if(ModelState.IsValid)
                {

                await _reviewService.AddReview(model);

                return RedirectToAction("Details", "Game", new { id = model.GameId });

                }
            Console.WriteLine(ModelState.ErrorCount);
            return RedirectToAction("Details", "Game", new { id = model.GameId });
        }
    }
}
