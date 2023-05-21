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
    public class PlayerSeeder : IPlayerSeeder
    {
        private readonly ApplicationDbContext _context;

        public PlayerSeeder(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Seed(PlayerRoot root)
        {
            foreach (var player in root.Data)
            {

                try
                {

                    Player convertedPlayer = new Player()
                    {

                        Id = player.id,
                        Position = player.position,
                        FirstName = player.first_name,
                        LastName = player.last_name,
                        HeightFeet = player.height_feet,
                        HeightInches = player.height_inches,
                        TeamId = player.team.Id,
                        WeightPounds = player.weight_pounds,

                    };
                    bool idExists = _context.Players.Any(p => p.Id == convertedPlayer.Id);
                    if (!idExists)
                    {
                        _context.Players.Add(convertedPlayer);
                        Console.WriteLine(root.Meta.current_page);
                    } else
                    {
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            _context.SaveChanges();
        }
    }
}
