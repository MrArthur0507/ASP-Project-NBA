using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.ViewModels;
using NBAProject.Data;
using Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.CrudRelated
{
    public class TeamCrudOperations : ITeamCrudOperations
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TeamCrudOperations(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TeamViewModel> GetAll()
        {
            List<Team> teams = _context.Teams.ToList();

            List<TeamViewModel> result = teams.Select(team => _mapper.Map<TeamViewModel>(team)).ToList();

            return result;

        }

        public TeamViewModel GetById(int teamId)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == teamId);

            TeamViewModel result = _mapper.Map<TeamViewModel>(team);

            return result;

        }


    }
}
