using AutoMapper;
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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public List<TeamViewModel> GetAllTeams()
        {
            List<Team> teams = _teamRepository.GetAllTeams();
            List<TeamViewModel> result = _mapper.Map<List<TeamViewModel>>(teams);
            return result;
        }

        public TeamViewModel GetTeamById(int teamId)
        {
            Team team = _teamRepository.GetTeamById(teamId);
            TeamViewModel result = _mapper.Map<TeamViewModel>(team);
            return result;
        }
    }
}
