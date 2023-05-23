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
    public class TeamSeeder : ITeamSeeder
    {
        private readonly ApplicationDbContext _context;
        public TeamSeeder(ApplicationDbContext context)
        {
           
        }
        public void Seed(PlayerRoot root, ApplicationDbContext _context)
        {

            foreach (var player in root.Data)
            {
                if (player.team != null && player.team.Id != 0)
                {

                    var existingTeam = _context.Teams.Local.FirstOrDefault(t => t.Id == player.team.Id);
                    if (existingTeam == null)
                    {
                        Team team = new Team()
                        {
                            Id = player.team.Id,
                            Name = player.team.Name,
                            Division = player.team.Division,
                            Abbreviation = player.team.Abbreviation,
                            City = player.team.City,
                            Conference = player.team.Conference,
                            Fullname = player.team.Fullname,
                        };
                        bool idExists = _context.Teams.Any(t => t.Id == team.Id);
                        if (!idExists)
                        {
                            _context.Teams.Add(team);
                            Console.WriteLine(root.Meta.current_page);
                        }
                        else
                        {
                            continue;
                        }
                       
                    }
                    else
                    {
                        continue;
                    }

                }

            }
           
        }
    }
}
