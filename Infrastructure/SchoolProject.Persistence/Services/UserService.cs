﻿using System;
using System.Xml.Linq;
using Mapster;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Services
{
    public class UserService : IUserService
    {
        IUserCommandRepository _userCommandRepository;
        IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector commentDataProtector;
        private readonly IDataProtector basketDataProtector;
        SchoolProjectDbContext context;

        public UserService(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IDataProtectionProvider dataProtectionProvider, SchoolProjectDbContext context)
        {
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
            basketDataProtector = dataProtectionProvider.CreateProtector("Baskets");
            this.context = context;
        }

        public async Task<UserDTO> AddAsync(AddUserDTO addUserDTO)
        {
                User user = await _userCommandRepository.AddAsync(new()
                {
                    NickName = addUserDTO.NickName,
                    Name = addUserDTO.Name,
                    Surname = addUserDTO.Surname,
                    Mail = addUserDTO.Mail,
                    PhoneNumber = addUserDTO.PhoneNumber,
                    Password = addUserDTO.Password
                });
                await _userCommandRepository.SaveAsync();
                return new()
                {
                    Id = userDataProtector.Protect(user.Id.ToString()),
                    Mail = user.Mail,
                    Name = user.Name,
                    NickName = user.NickName,
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                    ProfilePictureId = user.ProfilePictureId
                };
            
        }

        public async Task<UserDTO> DeleteAsync(string id)
        {
            User user = await _userCommandRepository.RemoveAsync(userDataProtector.Unprotect(id));
            _userCommandRepository.Update(user);
            await _userCommandRepository.SaveAsync();
            return new()
            {
                Id = userDataProtector.Protect(user.Id.ToString()),
                Mail = user.Mail,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureId = user.ProfilePictureId
            };
        }

        public async Task<(List<GetAllUsersDTO>, int totalCount)> GetAllAsync(int page, int size)
            => (await _userQueryRepository.GetAll().Where(u => u.IsActive == true).Skip(size * page).Take(size).Select(u => new GetAllUsersDTO
            {
                Id = userDataProtector.Protect(u.Id.ToString()),
                Mail = u.Mail,
                Name = u.Name,
                Surname = u.Surname,
                NickName = u.NickName,
                PhoneNumber = u.PhoneNumber,
                ProfilePictureId = u.ProfilePictureId
            }).ToListAsync(), await _userQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdUserDTO> GetByIdAsync(string id)
        {
            User?  user = await _userQueryRepository
                .Table
                .Include(c=>c.Posts)
                .ThenInclude(c => c.Comments)
                .ThenInclude(c => c.User)
                .Include(u=>u.Followees)
                .Include(u=>u.Followers)
                .Include(u=>u.Baskets)
                .ThenInclude(b=> b.Cryptos)
                .FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            List<PublicProfilesDTO> followers = user.Followers.Join(
                _userQueryRepository.GetAll(),
                uf =>uf.FolloweeId,
                user => user.Id,
                (uf,user)=> new PublicProfilesDTO
                {
                    Id = userDataProtector.Protect(user.Id.ToString()),
                    Name = user.Name,
                    Surname = user.Surname,
                    NickName = user.NickName,
                    ProfilePictureId = user.ProfilePictureId
                }).ToList();
            List<PublicProfilesDTO> followees = user.Followees.Join(
                _userQueryRepository.GetAll(),
                uf => uf.FollowerId,
                user => user.Id,
                (uf, user) => new PublicProfilesDTO
                {
                    Id = userDataProtector.Protect(user.Id.ToString()),
                    Name = user.Name,
                    Surname = user.Surname,
                    NickName = user.NickName,
                    ProfilePictureId = user.ProfilePictureId
                }).ToList();
            return new()
            {
                Id = userDataProtector.Protect(user.Id.ToString()),
                Mail = user.Mail,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber,
                Followers = followers,
                Follows = followees,
                ProfilePictureId = user.ProfilePictureId,
                Posts = user.Posts?.Select(p => new GetAllPostsDTO()
                {
                    UserId = userDataProtector.Protect(p.UserId.ToString()),
                    Id = postDataProtector.Protect(p.Id.ToString()),
                    Content = p.Content,
                    Title = p.Title,
                    LikeCount = p.LikeCount,
                    CreatedDate = p.CreatedDate,
                    OwnersName = user.NickName,
                    Comments = p.Comments?.Select(c => new CommentDTO()
                    {
                        UserId = userDataProtector.Protect(c.UserId.ToString()),
                        PostId = postDataProtector.Protect(c.PostId.ToString()),
                        Id = commentDataProtector.Protect(c.Id.ToString()),
                        Content = c.Content,
                        LikeCount = c.LikeCount,
                        CreatedDate = c.CreatedDate,
                        OwnersName = c.User.NickName
                    }).ToList() ?? new List<CommentDTO>()
                }
                ).ToList() ?? new List<GetAllPostsDTO>(),
                Comments = user.Comments?.Select(c => new GetAllCommentsDTO()
                {
                    PostId = postDataProtector.Protect(c.PostId.ToString()),
                    UserId = userDataProtector.Protect(c.UserId.ToString()),
                    Id = commentDataProtector.Protect(c.Id.ToString()),
                    Content = c.Content,
                    LikeCount = c.LikeCount,
                    CreatedDate = c.CreatedDate,
                    OwnersName = c.User.NickName
                }).ToList() ?? new List<GetAllCommentsDTO>(),
                Baskets = user.Baskets?.Select(b=> new GetAllBasketsDTO()
                {
                    UserId = userDataProtector.Protect(user.Id.ToString()),
                    Id = basketDataProtector.Protect(b.Id.ToString()),
                    OwnersName = user.NickName,
                    BasketName = b.BasketName,
                    LikeCount = b.LikeCount,
                    CreatedDate = b.CreatedDate,
                    Cryptos = b.Cryptos
                        .GroupBy(c => c.Symbol)
                        .Select(g => new CryptoDTO
                        {
                            Symbol = g.Key,
                            Cost = g.Sum(p=>p.Cost * p.Amount),
                            Amount = g.Sum(c => c.Amount),
                            CreatedDate = g.Min(c => c.CreatedDate)
                        }).ToList() ?? new List<CryptoDTO>(),   
                }).ToList() ?? new List<GetAllBasketsDTO>()
                
            };
        }

        public async Task<UserDTO> UpdateAsync(UpdateUserDTO updateUserDTO)
        {
            updateUserDTO.Id = userDataProtector.Unprotect(updateUserDTO.Id);
            User user1 = await _userQueryRepository.GetByIdAsync(updateUserDTO.Id);
            User user = updateUserDTO.Adapt<User>();
            user.Password = user1.Password;
            _userCommandRepository.Update(user);
            await _userCommandRepository.SaveAsync();
            return new()
            {
                Id = userDataProtector.Protect(user.Id.ToString()),
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Mail = user.Mail,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureId = user.ProfilePictureId
            };
        }
        public async Task<(UserDTO,UserDTO)> FollowAsync(string user1Id, string user2Id)
        {
            User? user1 = await _userQueryRepository.Table.Include(u => u.Followers).Include(u => u.Followees).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(user1Id)));
            User? user2 = await _userQueryRepository.Table.Include(u => u.Followers).Include(u => u.Followees).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(user2Id)));
            UserFollower uf = new()
            { 
                FolloweeId = user1.Id,
                FollowerId = user2.Id
            };
            context.UserFollowers.Add(uf);
            await _userCommandRepository.SaveAsync();
            return (new()
            {
                Id = userDataProtector.Protect(user1.Id.ToString()),
                Name = user1.Name,
                Surname = user1.Surname,
                NickName = user1.NickName,
                ProfilePictureId = user1.ProfilePictureId
            },
            new()
            {
                Id = userDataProtector.Protect(user2.Id.ToString()),
                Name = user2.Name,
                Surname = user2.Surname,
                NickName = user2.NickName,
                ProfilePictureId = user2.ProfilePictureId
            }
            );
        }

        public async Task<(List<GetAllPostsDTO>,  int totalCount)> GetUsersPostsAsync(string id)
        {
            User? user = await _userQueryRepository.Table.Include(u => u.Posts).ThenInclude(c => c.Comments).ThenInclude(c=>c.User).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)) || u.IsActive == true);
            return new(user?.Posts.Where(p => p.IsActive == true).Select(p => new GetAllPostsDTO()
            {
                UserId = userDataProtector.Protect(p.UserId.ToString()),
                Id = postDataProtector.Protect(p.Id.ToString()),
                Content = p.Content,
                Title = p.Title,
                LikeCount = p.LikeCount,
                CreatedDate = p.CreatedDate,
                OwnersName = p.User.NickName,
                ProfilePictureId = p.User.ProfilePictureId,
                Comments = p.Comments.Where(c => c.IsActive == true).Select(c => new CommentDTO()
                {
                    UserId = userDataProtector.Protect(c.UserId.ToString()),
                    PostId = postDataProtector.Protect(c.PostId.ToString()),
                    Id = commentDataProtector.Protect(c.Id.ToString()),
                    Content = c.Content,
                    LikeCount=c.LikeCount,
                    CreatedDate = c.CreatedDate,
                    OwnersName = c.User.NickName,
                    ProfilePictureId = c.User.ProfilePictureId
                }).ToList() ?? new List<CommentDTO>()
            }).ToList() ?? new List<GetAllPostsDTO>(),user.Posts.Count());
        }

        public async Task<(List<GetAllCommentsDTO>, int totalCount)> GetUsersCommentsAsync(string id)
        {
            User? user = await _userQueryRepository.Table.Include(c => c.Comments).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            return new(user.Comments.Where( c=>c.IsActive == true).Select(c=>new GetAllCommentsDTO()
            {
                UserId = userDataProtector.Protect(c.UserId.ToString()),
                PostId = postDataProtector.Protect(c.PostId.ToString()), 
                Id = commentDataProtector.Protect(c.Id.ToString()),
                Content = c.Content,
                LikeCount = c.LikeCount,
                CreatedDate = c.CreatedDate
            }).ToList() ?? new List<GetAllCommentsDTO>(), user.Comments.Count());
        }
        public async Task<(UserDTO, UserDTO)> UnFollowAsync(string user1Id, string user2Id)
        {
            User? user1 = await _userQueryRepository.Table.Include(u => u.Followers).Include(u => u.Followees).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(user1Id)));
            User? user2 = await _userQueryRepository.Table.Include(u => u.Followers).Include(u => u.Followees).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(user2Id)));
            UserFollower uf = new()
            {
                FolloweeId = user1.Id,
                FollowerId = user2.Id
            };
            context.UserFollowers.Remove(uf);
            await _userCommandRepository.SaveAsync();
            return (new()
            {
                Id = userDataProtector.Protect(user1.Id.ToString()),
                Name = user1.Name,
                Surname = user1.Surname,
                NickName = user1.NickName,
                ProfilePictureId = user1.ProfilePictureId
            },
            new()
            {
                Id = userDataProtector.Protect(user2.Id.ToString()),
                Name = user2.Name,
                Surname = user2.Surname,
                NickName = user2.NickName,
                ProfilePictureId = user2.ProfilePictureId
            }
            );
        }

    }
}

