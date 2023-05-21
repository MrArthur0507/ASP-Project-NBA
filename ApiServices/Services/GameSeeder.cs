using ApiServices.Contracts;
using Models.ApiModels;
using Models.DbModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services
{
	public class GameSeeder : IGameSeeder
	{
		private readonly ApplicationDbContext _context;

		public GameSeeder(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Seed(GameRoot input)
		{
			foreach (var game in input.Data)
			{
				bool idExits = _context.Games.Any(g => g.Id == game.id);

				if (!idExits) {
					
					Game convertedGame = new Game()
					{
						Id = game.id,
						Date = game.date,
						HomeTeamId = game.home_team.id,
						HomeTeamScore = game.home_team_score,
						VisitorTeamId = game.visitor_team.id,
						VisitorTeamScore = game.visitor_team_score,
						Period = game.period,
						PostSeason = game.postseason,
						Season = game.season,
						Status = game.status,
						Time = game.time,


					};
					_context.Games.Add(convertedGame);
				}
			}
			_context.SaveChanges();
		}
	}
}
