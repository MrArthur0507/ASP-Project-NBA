using ApiServices.Contracts;
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
    public class FetchPlayer : BasicFetcher, IFetchPlayer
    {
       
        private readonly ITeamSeeder _teamSeeder;
        private readonly IPlayerSeeder _playerSeeder;

        public FetchPlayer(ITeamSeeder teamSeeder, IPlayerSeeder playerSeeder, HttpClient client, ApplicationDbContext context) : base(context, client)
        {
            
            _teamSeeder = teamSeeder;
            _playerSeeder = playerSeeder;
        }

        public async Task FetchPlayersWithDelay()
        {
            string apiUrl = "https://www.balldontlie.io/api/v1/";
            string playersEndpoint = "players";
            int delayMilliseconds = 1000;
            int page = 1;
            int maxPage = 1;
            List<Player> players = new List<Player>();
                while (true)
                {
                    string requestUrl = $"{apiUrl}{playersEndpoint}?per_page=100&page={page}";
                    HttpResponseMessage response = await _client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        PlayerRoot root = JsonConvert.DeserializeObject<PlayerRoot>(jsonResponse);
                        _teamSeeder.Seed(root, _context);
                        _playerSeeder.Seed(root, _context, players);
                        
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
                _context.Players.AddRange(players);
                _context.SaveChanges();
            
            _client.Dispose();

        }
    }
}
