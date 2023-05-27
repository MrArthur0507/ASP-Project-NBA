using ApiServices.Contracts;
using AutoMapper;
using Models.ApiModels;
using Models.AutoMapper;
using Models.DbModels;
using NBAProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services.MicroService
{
    public class TeamSeeder : ITeamSeeder
    {

        
        public void Seed(PlayerRoot root, ApplicationDbContext _context)
        {
            foreach (var player in root.Data)
            {

                var existingTeam = _context.Teams.Local.FirstOrDefault(t => t.Id == player.team.id);
                if (existingTeam == null)
                {
                    
                    if (!_context.Teams.Any(t => t.Id == player.team.id))
                    {
                        _context.Teams.Add(Convert(player));
                    }
                }

            }

        }


        private Team Convert(PlayerApi player)
        {
            Team team = new Team()
            {
                Id = player.team.id,
                Name = player.team.name,
                Division = player.team.division,
                Abbreviation = player.team.abbreviation,
                City = player.team.city,
                Conference = player.team.conference,
                Fullname = player.team.full_name,
            };
            return team;
        }

    }
}

