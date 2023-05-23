﻿using ApiServices.Contracts;
using Models.ApiModels;
using Models.DbModels;
using NBAProject.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services
{
    public class FetchPlayer : IFetchPlayer
    {
       
        private readonly ITeamSeeder _teamSeeder;
        private readonly IPlayerSeeder _playerSeeder;

        public FetchPlayer(ITeamSeeder teamSeeder, IPlayerSeeder playerSeeder)
        {
            
            _teamSeeder = teamSeeder;
            _playerSeeder = playerSeeder;
        }

        public async Task FetchPlayersWithDelay(ApplicationDbContext _context)
        {
           

            HttpClient client = new HttpClient();
            string apiUrl = "https://www.balldontlie.io/api/v1/";
            string playersEndpoint = "players";
            int delayMilliseconds = 1000;
            int page = 1;
            int maxPage = 1;
           
            while (true)
            {
                string requestUrl = $"{apiUrl}{playersEndpoint}?per_page=100&page={page}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    PlayerRoot root = JsonConvert.DeserializeObject<PlayerRoot>(jsonResponse);
                    Console.WriteLine(jsonResponse);
                    _teamSeeder.Seed(root, _context);
                    _playerSeeder.Seed(root, _context);
                    
                    await Task.Delay(delayMilliseconds);

                    maxPage = root.Meta.total_pages;
                    page++;


                    if (page == maxPage)
                        break;
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                    break;
                }
            }

            _context.SaveChanges();
            client.Dispose();

        }
    }
}
