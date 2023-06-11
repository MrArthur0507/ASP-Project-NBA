using Microsoft.AspNetCore.Mvc.Rendering;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GameCrudOperations : IGameCrudOperations
    {
        private readonly ApplicationDbContext _context;
        public GameCrudOperations(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public SelectTeamViewModel GetSelect()
        {
            SelectTeamViewModel model = new SelectTeamViewModel();
            List<Team> teams = _context.Teams.ToList();
            foreach (var team in teams)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Text = team.Name,
                    Value = team.Id.ToString(),
                };
                model.SelectedTeam.Add(listItem);
            }
            Console.WriteLine(model.SelectedTeam.Count);
            return model;
        }
        public List<Game> GetGames(int visitorTeamId, int homeTeamId)
        {
            List<Game> games = _context.Games.Where(g => g.VisitorTeamId == visitorTeamId && g.HomeTeamId == homeTeamId).ToList();
            return games;
            
        }

    }
}
