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
    public class StatSeeder : IStatSeeder
    {
        private readonly ApplicationDbContext _context;
        public StatSeeder(ApplicationDbContext context) { 
            _context = context; 
        }

        public void Seed(StatRoot root)
        {
            foreach (var stat in root.Data)
            {
                bool idExists = _context.Stats.Any(s => s.Id == stat.id);
                try
                {
                    if (!idExists)
                    {
                        Stat convertedStat = new Stat()
                        {
                            Id = stat.id,
                            DefensiveRebounds = stat.dreb,
                            Assists = stat.ast,
                            Blocks = stat.blk,
                            Points = stat.pts,
                            OffensiveRebounds = stat.oreb,
                            Steals = stat.stl,
                            Turnovers = stat.turnover,
                            TotalRebounds = stat.reb,
                            Minutes = stat.min,
                            PersonalFouls = stat.pf,
                            FieldGoalPercentage = stat.fg_pct,
                            FieldGoalsAttempted = stat.fga,
                            FieldGoalsMade = stat.fgm,
                            FreeThrowPercentage = stat.ft_pct,
                            FreeThrowsAttempted = stat.fta,
                            FreeThrowsMade = stat.ftm,
                            ThreePointFieldGoalPercentage = stat.fg3_pct,
                            ThreePointFieldGoalsAttempted = stat.fg3a,
                            ThreePointFieldGoalsMade = stat.fg3m,
                            GameId = stat.game.id,
                            PlayerId = stat.player.id,
                            TeamId = stat.team.id,
                        };
                        if (_context.Games.Any(g => g.Id == convertedStat.GameId))
                        {
                            _context.Stats.Add(convertedStat);
                            
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            _context.SaveChanges();

        }
    }
}
