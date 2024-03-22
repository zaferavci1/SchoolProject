using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
    public class PublicProfileService : IPublicProfileService
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector commentDataProtector;

        public PublicProfileService(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
        }

        public async Task<PublicProfilesDTO> AddAsync(AddPublicProfilesDTO addPublicProfilesDTO)
        {
            throw new NotImplementedException();
        }

        public Task<PublicProfilesDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<GetAllPublicProfilesDTO>, int totalCount)> GetAllAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdPublicProfileDTO> GetByIdAsync(string id)
        {
            User? user = await _userQueryRepository.Table.Include(u => u.Posts).ThenInclude(c => c.Comments).Include(u => u.Followers).Include(u => u.Follows).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            return new()
            {
                Id = userDataProtector.Protect(user.Id.ToString()),
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Followers = user.Followers?.Select(f => new PublicProfilesDTO()
                {
                    Id = userDataProtector.Protect(f.Id.ToString()),
                    Name = f.Name,
                    Surname = f.Surname,
                    NickName = f.NickName
                }).ToList() ?? new List<PublicProfilesDTO>(),
                Follows = user.Follows?.Select(f => new PublicProfilesDTO()
                {
                    Id = userDataProtector.Protect(f.Id.ToString()),
                    Name = f.Name,
                    Surname = f.Surname,
                    NickName = f.NickName
                }).ToList() ?? new List<PublicProfilesDTO>(),
                Posts = user.Posts?.Select(p => new GetAllPostsDTO()
                {
                    UserId = userDataProtector.Protect(p.UserId.ToString()),
                    Id = postDataProtector.Protect(p.Id.ToString()),
                    Content = p.Content,
                    Title = p.Title,
                    LikeCount = p.LikeCount,
                    Comments = p.Comments.Select(c => new CommentDTO()
                    {
                        UserId = userDataProtector.Protect(c.UserId.ToString()),
                        PostId = postDataProtector.Protect(c.PostID.ToString()),
                        Id = commentDataProtector.Protect(c.Id.ToString()),
                        Content = c.Content,
                        LikeCount = c.LikeCount
                    }).ToList() ?? new List<CommentDTO>()
                }
                ).ToList() ?? new List<GetAllPostsDTO>(),
                Comments = user.Comments.Select(c => new GetAllCommentsDTO()
                {
                    PostId = postDataProtector.Protect(c.PostID.ToString()),
                    UserId = userDataProtector.Protect(c.UserId.ToString()),
                    Id = commentDataProtector.Protect(c.Id.ToString()),
                    Content = c.Content,
                    LikeCount = c.LikeCount
                }).ToList() ?? new List<GetAllCommentsDTO>()
            };
        }

        public Task<PublicProfilesDTO> UpdateAsync(UpdatePublicProfileDTO updatePublicProfileDTO)
        {
            throw new NotImplementedException();
        }
    }
}

