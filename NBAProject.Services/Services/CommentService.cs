using AutoMapper;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Models.DbModels;
using Models.ViewModels;
using ProjectData.Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IHttpContextAccessor _contextAccessor)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _httpContextAccessor = _contextAccessor;
        }

        public async Task AddComment(CommentViewModel comment, int gameId)
        {
            
            Comment commentModel = _mapper.Map<Comment>(comment);
            commentModel.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            commentModel.GameId = gameId;
            await _commentRepository.AddComment(commentModel);
        }

        public async Task<List<CommentViewModel>> GetCommentsByGameId(int gameId)
        {
            var comments = await _commentRepository.GetCommentsByGameId(gameId);
            return _mapper.Map<List<CommentViewModel>>(comments);
        }

        public async Task<CommentViewModel> GetCommentById(int commentId)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            return _mapper.Map<CommentViewModel>(comment);
        }

        public async Task DeleteComment(int commentId)
        {
            await _commentRepository.DeleteComment(commentId);
        }
    }
}
