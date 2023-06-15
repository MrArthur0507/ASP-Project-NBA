using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.DbModels;
using Models.ViewModels;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper, ITeamRepository teamRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public SelectTeamViewModel GetSelect()
        {
            SelectTeamViewModel model = new SelectTeamViewModel();
            List<Team> teams = _teamRepository.GetAllTeams();

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
            List<Game> games = _gameRepository.GetGames(visitorTeamId, homeTeamId);
            List<GameViewModel> gameViewModels = _mapper.Map<List<GameViewModel>>(games);
            List<GameViewModel> orderedGames = gameViewModels.OrderByDescending(g => g.Season).ToList();
            return orderedGames;
        }
    }
}
