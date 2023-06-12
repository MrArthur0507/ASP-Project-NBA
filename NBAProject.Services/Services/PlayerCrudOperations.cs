using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
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
using X.PagedList;

namespace Services.Services
{
    public class PlayerCrudOperations : IPlayerCrudOperations
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        const int pageSize = 25;
        public PlayerCrudOperations(ApplicationDbContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }
        
		public IPagedList<PlayerViewModel> GetByPage(int page)
		{
            if (page == 0)
            {
                page = 1;
            }


            IEnumerable<Player> players = _context.Players.AsEnumerable();
			List<PlayerViewModel> result = players.Select(player => _mapper.Map<PlayerViewModel>(player)).ToList();
			IPagedList<PlayerViewModel> list = result.ToPagedList(page, pageSize);
            return list;
		}

		public async Task<PlayerDetailsViewModel> GetById(int id)
        {
            

			var player = await _context.Players
                .Include(player => player.Team)
            .FirstOrDefaultAsync(player => player.Id == id);
            PlayerDetailsViewModel result = _mapper.Map<PlayerDetailsViewModel>(player);
            
            return result;
        }

        public async Task<CreatePlayerViewModel> Create()
        {
            CreatePlayerViewModel createPlayerViewModel = new CreatePlayerViewModel();
            ICollection<Team> teams =  await _context.Teams.ToListAsync();
                foreach (var team in teams)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Text = team.Name,
                    Value = team.Id.ToString(),
                };

                createPlayerViewModel.SelectedTeam.Add(listItem);
            }

            return createPlayerViewModel;
        }


        public async Task Update(PlayerViewModel playerViewModel)
        {
            var player = await _context.Players.FindAsync(playerViewModel.Id);
            if (player == null)
            {
                throw new ArgumentException("Player not found.");
            }

            _mapper.Map(playerViewModel, player);
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
