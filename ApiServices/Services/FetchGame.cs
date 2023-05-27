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
	public class FetchGame : BasicFetcher, IFetchGame
	{
		private readonly IGameSeeder _gameSeeder;

		public FetchGame(IGameSeeder gameSeeder, HttpClient client, ApplicationDbContext context) : base(context, client)
		{
			_gameSeeder = gameSeeder;
		}
		public async Task FetchGames()
		{
			string apiUrl = "https://www.balldontlie.io/api/v1/";
			string playersEndpoint = "games";
			int delayMilliseconds = 1100;
			int page = 1;
			int maxPage = 1;
			List<Game> games = new List<Game>();
			
				while (true)
				{
					string requestUrl = $"{apiUrl}{playersEndpoint}?per_page=100&page={page}";
					HttpResponseMessage response = await _client.GetAsync(requestUrl);

					if (response.IsSuccessStatusCode)
					{
						string jsonResponse = await response.Content.ReadAsStringAsync();
						GameRoot root = JsonConvert.DeserializeObject<GameRoot>(jsonResponse);
						Console.WriteLine(jsonResponse);
						_gameSeeder.Seed(root, _context, games);

						await Task.Delay(delayMilliseconds);

						maxPage = root.Meta.total_pages;
						page++;


						if (page == maxPage)
						{
							break;
						}
						else if (page % 50 == 0)
						{
							_context.AddRange(games);
							_context.SaveChanges();
							games.Clear();
						}
					}
					else
					{
						Console.WriteLine("Request failed with status code: " + response.StatusCode);
						break;
					}
				}

				_context.Games.AddRange(games);
				_context.SaveChanges();
                _client.Dispose();
            
			

		}
	}
}

