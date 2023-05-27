using ApiServices.Contracts;
using Models.ApiModels;
using Models.DbModels;
using NBAProject.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services.MicroService
{
    public class PlayerSeeder : BasicSeeder,  IPlayerSeeder
    {
        
        public PlayerSeeder(IPrint print) : base(print)
        {

        }
        
        public void Seed(PlayerRoot root, ApplicationDbContext _context, List<Player> players)
        {
            
            foreach (var player in root.Data)
            {
                
                try
                {
                    bool idExists = _context.Players.Any(p => p.Id == player.id);
                    bool ExistsInList = players.Any(p => p.Id == player.id);
                    if (!idExists)
                    {

                        players.Add(Convert(player));
                        
                    }

                }
                catch (Exception ex)
                {
                    _print.PrintMsg(ex.Message);
                }
            }
            

        }

        private Player Convert(PlayerApi player)
        {
            Player convertedPlayer = new Player()
            {

                Id = player.id,
                Position = player.position,
                FirstName = player.first_name,
                LastName = player.last_name,
                HeightFeet = player.height_feet,
                HeightInches = player.height_inches,
                TeamId = player.team.id,
                WeightPounds = player.weight_pounds,

            };
            return convertedPlayer; 
        }

    }
}
