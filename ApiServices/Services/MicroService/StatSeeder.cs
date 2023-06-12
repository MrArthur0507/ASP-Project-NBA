using ApiServices.Contracts;
using Models.ApiModels;
using Models.DbModels;
using NBAProject.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServices.Services.MicroService
{
    public class StatSeeder : BasicSeeder, IStatSeeder
    {
        public StatSeeder(IPrint print) : base(print)
        {

        }
        public List<Stat> Seed(StatRoot root, ApplicationDbContext context, List<Stat> stats)
        {
            foreach (var stat in root.Data)
            {
                bool idExists = context.Stats.Any(s => s.Id == stat.id);
                bool existsInList = stats.Any(s => s.Id == stat.id);
                try
                {
                    if (!idExists && !existsInList)
                    {
                        Stat convertedStat = Convert(stat);
                        if (context.Games.Any(g => g.Id == convertedStat.GameId && context.Players.Any(p => p.Id == stat.player.id)))
                        {
                            stats.Add(convertedStat);

                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return stats;

        }

        private Stat Convert(StatApi stat)
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
            return convertedStat;
        }

    }
}

