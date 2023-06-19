using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.DbModels;
using Models.ViewModels;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private const int pageSize = 25;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public IPagedList<PlayerViewModel> GetPlayersByPage(int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            var players = _playerRepository.GetAll();
            var playerViewModels = players.ToPagedList(page, 25);
            var result = playerViewModels.Select(player => _mapper.Map<PlayerViewModel>(player));
            return result;
        }

        public async Task<PlayerDetailsViewModel> GetPlayerById(int id)
        {
            var player = await _playerRepository.GetById(id);
            return _mapper.Map<PlayerDetailsViewModel>(player);
        }


        public List<PlayerViewModel> SearchPlayers(string searchTerm)
        {
            var players = _playerRepository.SearchPlayers(searchTerm);
            return players.Select(player => new PlayerViewModel
            {
                Id = player.Id,
                FirstName = player.FirstName,
                HeightFeet = player.HeightFeet,
                HeightInches = player.HeightInches,
                LastName = player.LastName,
                Position = player.Position,
                WeightPounds = player.WeightPounds
            }).ToList();
        }

        public List<PlayerViewModel> GetPlayersByTeam(int teamId)
        {
            List<Player> players = _playerRepository.GetPlayersByTeamId(teamId);
            List<PlayerViewModel> playerViewModels = players.Select(player => _mapper.Map<PlayerViewModel>(player)).ToList();
            return playerViewModels;
        }

        public async Task AddPlayer(PlayerViewModel player)
        {
            Player input = _mapper.Map<Player>(player);

            await _playerRepository.AddPlayer(input);
        }
    }
}
