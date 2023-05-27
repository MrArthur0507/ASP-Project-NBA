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
    public class FetchStat : BasicFetcher, IFetchStat
    {
        private readonly IStatSeeder _statSeeder;

        private readonly ApplicationDbContext _context;
        public FetchStat(IStatSeeder statSeeder, ApplicationDbContext context, HttpClient client) : base(context, client) {
            _statSeeder = statSeeder;
            _context = context;
        }

       
        public async Task FetchStats()
        {
            string apiUrl = "https://www.balldontlie.io/api/v1/";
            string playersEndpoint = "stats";
            int delayMilliseconds = 1000;
            int page = 1;
            int maxPage = 1;
            List<Stat> stats = new List<Stat>();
            while (true)
            {
                string requestUrl = $"{apiUrl}{playersEndpoint}?per_page=100&page={page}";
                HttpResponseMessage response = await _client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    StatRoot root = JsonConvert.DeserializeObject<StatRoot>(jsonResponse);
                    _statSeeder.Seed(root, _context, stats);
                    await Task.Delay(delayMilliseconds);
                    maxPage = root.Meta.total_pages;
                    page++;

                    if (page == maxPage)
                    {
                        break;
                    } else if (page % 100 == 0)
                    {
                        _context.AddRange(stats);
                        _context.SaveChanges();
                        stats.Clear();
                    }
                        
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                    break;
                }
            }
            _context.AddRange(stats);
            _context.SaveChanges();
            _client.Dispose();
        }
        
    }
}
