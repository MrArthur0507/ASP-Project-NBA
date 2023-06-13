using AutoMapper;
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

namespace Services.Services.CrudRelated
{
    public class GameCrudOperations : IGameCrudOperations
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        public GameCrudOperations(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public List<GameViewModel> GetGames(int visitorTeamId, int homeTeamId)
        {
            List<Game> result = _context.Games.Where(g => g.VisitorTeamId == visitorTeamId && g.HomeTeamId == homeTeamId).ToList();
            List<GameViewModel> games = result.Select(game => _mapper.Map<GameViewModel>(game)).ToList();
            List<GameViewModel> orderedGames = games.OrderByDescending(g => g.Season).ToList();
            return orderedGames;

        }

    }
}
