using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using Services.Contracts;

namespace NBAProject.Controllers
{
    public class StatController : Controller
    {
        private readonly IStatOperations _statOperation;
        public StatController(IStatOperations statOperations) {
            _statOperation = statOperations;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetBasicStatsByPlayerId(int id)
        {

            return Json(await _statOperation.GetBasicStatsByPlayerId(id));
        }

        public async Task<IActionResult> GetTotalForGame(int id)
        {
            StatGameTotalViewModel total =  await _statOperation.GetTotalForGame(id);
           
            return Json(total.GameTotal);
        }
    }
}
