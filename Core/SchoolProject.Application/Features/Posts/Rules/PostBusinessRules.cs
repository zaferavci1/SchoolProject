using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Exceptions;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Posts.Rules
{
	public class PostBusinessRules
	{
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IPostQueryRepository _postQueryRepository;
        private readonly IDataProtector _userDataProtector;
        private readonly IDataProtector _postDataProtector;
        public PostBusinessRules(IUserQueryRepository userQueryRepository, IPostQueryRepository postQueryRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userQueryRepository = userQueryRepository;
            _postQueryRepository = postQueryRepository;
            _userDataProtector = dataProtectionProvider.CreateProtector("Users");
            _postDataProtector = dataProtectionProvider.CreateProtector("Posts");
        }
        public async Task IsPostExist(string id)
        {
            Post? post = await _postQueryRepository.GetByIdAsync(_postDataProtector.Unprotect(id));
            if (post == null) throw new CustomException<PostDTO>("Post Not Exist");
        }
        public async Task IsPostActive(string id)
        {
            Post? post = await _postQueryRepository.GetByIdAsync(_postDataProtector.Unprotect(id));
            if (!post.IsActive) throw new CustomException<PostDTO>("Post Not Active");
        }
        public async Task IsPostAllreadyLiked(string postId,string userId)
        {
            bool check = await _userQueryRepository.Table.Include(u => u.PostLikes).AnyAsync(u => u.PostLikes.Any(pl => pl.PostId == Guid.Parse(_postDataProtector.Unprotect(postId)) && pl.UserId == Guid.Parse(_userDataProtector.Unprotect(userId))));
            if (!check) throw new CustomException<PostDTO>("Post Not Liked");
        }
        public async Task IsPostLiked(string postId, string userId)
        {
            bool check = await _userQueryRepository.Table.Include(u => u.PostLikes).AnyAsync(u => u.PostLikes.Any(pl => pl.PostId == Guid.Parse(_postDataProtector.Unprotect(postId)) && pl.UserId == Guid.Parse(_userDataProtector.Unprotect(userId)   )));
            if (check) throw new CustomException<PostDTO>("Post Allready Liked");
        }
        public async Task IsOwnerCorrect(string postId, string userId)
        {
            Post? post = await _postQueryRepository.GetByIdAsync(_postDataProtector.Unprotect(postId));
            if (post.UserId != Guid.Parse(_userDataProtector.Unprotect(userId))) throw new CustomException<PostDTO>("Owner Not Correct");
        }
    }
}

