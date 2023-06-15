using AutoMapper;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.ViewModels;
using ProjectData.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<ApplicationUser> users = await _userRepository.GetAll();
            List<UserViewModel> userViews = users.Select(user => _mapper.Map<UserViewModel>(user)).ToList();
            return userViews;
        }

        public async Task<UserViewModel> GetUserById(string userId)
        {
            ApplicationUser user = await _userRepository.GetUserById(userId);
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task<UserViewModel> GetUserByUsername(string username)
        {
            ApplicationUser user = await _userRepository.GetUserByUsername(username);
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

    }
}
