using ApiServices.Contracts;
using Microsoft.IdentityModel.Tokens;
using Models.ApiModels;
using Models.DbModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services.MicroService
{
    public class GameSeeder : IGameSeeder
    {

        
        public void Seed(GameRoot input, ApplicationDbContext _context, List<Game> games)
        {
            foreach (var game in input.Data)
            {
                bool idExists = _context.Games.Any(g => g.Id == game.id);
                bool idExistsinList = games.Any(g => g.Id == game.id);
                if (!idExists && !idExistsinList)
                {
                    games.Add(Convert(game));
                    
                }
            }
        }

        private Game Convert(GameApi game)
        {
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
            return convertedGame;
        }
    }

    



}


