﻿using ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.ApiModels;
using Models.DbModels;
using Newtonsoft.Json;

namespace NBAProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFetchData _fetchData;
        public AdminController(IFetchData fetchData) {
            _fetchData = fetchData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPlayers()
        {
            await _fetchData.Fetch();

            return View();
        }
    }
}
