using ApiServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using NBAProject.Models;
using Services.Contracts;
using System.Diagnostics;

namespace NBAProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlayerCrudOperations _playerServices;
        public HomeController(ILogger<HomeController> logger, IPlayerCrudOperations playerServices)
        {
            _logger = logger;
            _playerServices = playerServices;
        }

        public async Task<ViewResult> Index()
        {
            
            return View(await _playerServices.GetAll());
        }

        public async Task<ViewResult> Details(int id)
        {

            return View(await _playerServices.GetById(id));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}