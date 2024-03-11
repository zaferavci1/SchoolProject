using System;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Repository.PublicProfiles;
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

        public PublicProfileService(IPublicProfileQueryRepository publicProfileQueryRepository, IPublicProfileCommandRepository publicProfileCommandRepository, IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
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
            User? user = await _userQueryRepository.Table.Include(u => u.Posts).ThenInclude(p => p.Comments).Include(u => u.Followers).Include(u => u.Follows).FirstOrDefaultAsync(u => u.Id == Guid.Parse(id));
            User user = await _userQueryRepository.GetByIdAsync(id);
            return new()
            {
                Id = Convert.ToString(user.Id),
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Followers = user.Followers?.Select(f => new PublicProfilesDTO()
                {
                    Id = Convert.ToString(f.Id),
                    Name = f.Name,
                    Surname = f.Surname,
                    NickName = f.NickName
                }).ToList() ?? new List<PublicProfilesDTO>(),
                Follows = user.Follows?.Select(f => new PublicProfilesDTO()
                {
                    Id = Convert.ToString(f.Id),
                    Name = f.Name,
                    Surname = f.Surname,
                    NickName = f.NickName
                }).ToList() ?? new List<PublicProfilesDTO>(), 
                Posts = user.Posts?.Select(p=> new GetAllPostsDTO() {
                    Id = Convert.ToString(p.Id) ,
                    Content = p.Content,
                    Title= p.Title,
                    Comments = p.Comments?.Select(c => new CommentDTO()
                    {
                        Id  = Convert.ToString(c.Id),
                        Content = c.Content,
                    }).ToList() ?? new List<CommentDTO>()
                }).ToList() ?? new List<GetAllPostsDTO>()
            };
        }

        public Task<PublicProfilesDTO> UpdateAsync(UpdatePublicProfileDTO updatePublicProfileDTO)
        {
            throw new NotImplementedException();
        }
    }
}

