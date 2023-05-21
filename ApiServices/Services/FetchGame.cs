using ApiServices.Contracts;
using Models.ApiModels;
using Models.DbModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services
{
	public class FetchGame : IFetchGame
	{
		private readonly IGameSeeder _gameSeeder;

		public FetchGame(IGameSeeder gameSeeder)
		{
			_gameSeeder = gameSeeder;
		}
		public async Task FetchGames()
		{
			HttpClient client = new HttpClient();
			string apiUrl = "https://www.balldontlie.io/api/v1/";
			string playersEndpoint = "games";
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
					GameRoot root = JsonConvert.DeserializeObject<GameRoot>(jsonResponse);
					Console.WriteLine(jsonResponse);
					_gameSeeder.Seed(root);

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


			client.Dispose();

		}
	}
}

