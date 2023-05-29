﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    public class PlayerCrudOperations : IPlayerCrudOperations
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PlayerCrudOperations(ApplicationDbContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }
        public List<PlayerViewModel> GetAll()
        {
            
            
            List<Player> players = _context.Players.ToList();

            List<PlayerViewModel> result = players.Select(player => _mapper.Map<PlayerViewModel>(player)).ToList();

            return result.ToList();
        }

        public PlayerDetailsViewModel GetById(int id)
        {
            Player player =  _context.Players.Include(p => p.Team).FirstOrDefault(p => p.Id == id);
            PlayerDetailsViewModel result = _mapper.Map<PlayerDetailsViewModel>(player);
            return result;
        }

        public async Task Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
