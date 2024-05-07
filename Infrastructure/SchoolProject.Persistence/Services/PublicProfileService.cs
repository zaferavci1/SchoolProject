using System;
using Mapster;
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
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector commentDataProtector;

        public PublicProfileService(IUserQueryRepository userQueryRepository,IDataProtectionProvider dataProtectionProvider)
        {
            _userQueryRepository = userQueryRepository;
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
            User? user = await _userQueryRepository.Table
                .Include(u => u.Posts)
                .ThenInclude(c => c.Comments)
                .ThenInclude(u=>u.User)
                .Include(c=>c.Comments)
                .ThenInclude(c=>c.ReplyComments)
                .Include(u => u.Followees)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            List<PublicProfilesDTO> followers = user.Followers.Join(
               _userQueryRepository.GetAll(),
               uf => uf.FolloweeId,
               user => user.Id,
               (uf, user) => new PublicProfilesDTO
               {
                   ProfilePictureId = user.ProfilePictureId,
                   Id = user.Id.ToString(),
                   Name = user.Name,
                   Surname = user.Surname,
                   NickName = user.NickName
               }).ToList() ?? new List<PublicProfilesDTO>();

            List<PublicProfilesDTO> followees = user.Followees.Join(
                _userQueryRepository.GetAll(),
                uf => uf.FollowerId,
                user => user.Id,
                (uf, user) => new PublicProfilesDTO
                {
                    ProfilePictureId = user.ProfilePictureId,
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Surname = user.Surname,
                    NickName = user.NickName
                }).ToList() ?? new List<PublicProfilesDTO>();

            var a = new GetByIdPublicProfileDTO()
            {
                ProfilePictureId = user.ProfilePictureId,
                Id = userDataProtector.Protect(user.Id.ToString()),
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Followers = followers ,
                Follows = followees ,
                Posts = user.Posts?.Select(p => new GetAllPostsDTO()
                {
                    UserId = userDataProtector.Protect(p.UserId.ToString()),
                    Id = postDataProtector.Protect(p.Id.ToString()),
                    Content = p.Content,
                    Title = p.Title,
                    LikeCount = p.LikeCount,
                    CreatedDate = p.CreatedDate,
                    OwnersName= p.User.NickName,
                    ProfilePictureId = p.User.ProfilePictureId,
                    Comments = p.Comments.Select(c => new CommentDTO()
                    {
                        UserId = userDataProtector.Protect(c.UserId.ToString()),
                        PostId = postDataProtector.Protect(c.PostId.ToString()),
                        Id = commentDataProtector.Protect(c.Id.ToString()),
                        Content = c.Content,
                        LikeCount = c.LikeCount,
                        CreatedDate = c.CreatedDate,
                        OwnersName = c.User.NickName,
                        ProfilePictureId = c.User.ProfilePictureId
                    }).ToList() ?? new List<CommentDTO>()
                }).ToList() ?? new List<GetAllPostsDTO>(),
                Comments = user.Comments.Select(c => new GetAllCommentsDTO()
                {
                    PostId = postDataProtector.Protect(c.PostId
                    .ToString()),
                    UserId = userDataProtector.Protect(c.UserId.ToString()),
                    Id = commentDataProtector.Protect(c.Id.ToString()),
                    Content = c.Content,
                    LikeCount = c.LikeCount,
                    CreatedDate = c.CreatedDate,
                    OwnersName = user.NickName,
                    ProfilePictureId= user.ProfilePictureId
                }).ToList() ?? new List<GetAllCommentsDTO>()
            };
            Console.WriteLine();
            return a;
        }

        public Task<PublicProfilesDTO> UpdateAsync(UpdatePublicProfileDTO updatePublicProfileDTO)
        {
            throw new NotImplementedException();
        }
    }
}

