using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
    public class UserService : IUserService
    {
        IUserCommandRepository _userCommandRepository;
        IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector commentDataProtector;

        public UserService(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
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
                    Password = addUserDTO.password
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
                    Password = user.Password
                };
            
        }

        public async Task<UserDTO> DeleteAsync(string id)
        {
            User user = await _userCommandRepository.RemoveAsync(userDataProtector.Unprotect(id));
            await _userCommandRepository.SaveAsync();
            return new()
            {
                Id = userDataProtector.Protect(user.Id.ToString()),
                Mail = user.Mail,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password
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
                PhoneNumber = u.PhoneNumber
            }).ToListAsync(), await _userQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdUserDTO> GetByIdAsync(string id)
        {
            User? user = await _userQueryRepository.Table.Include(u => u.Posts).ThenInclude(c => c.Comments).Include(u => u.Followers).Include(u => u.Follows).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            return new()
            {
                Id = userDataProtector.Protect(user.Id.ToString()),
                Mail = user.Mail,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber,
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

        public async Task<UserDTO> UpdateAsync(UpdateUserDTO updateUserDTO)
        {
            User user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(updateUserDTO.Id));
            user.Name = updateUserDTO.Name == "string" ? user.Name : updateUserDTO.Name;
            user.Surname = updateUserDTO.Surname == "string" ? user.Surname : updateUserDTO.Surname;
            user.NickName = updateUserDTO.NickName == "string" ? user.NickName : updateUserDTO.NickName;
            user.Mail = updateUserDTO.Mail == "string" ? user.Mail : updateUserDTO.Mail;
            user.IsActive = updateUserDTO.IsActive == default ? user.IsActive : updateUserDTO.IsActive;
            user.IsProfilePrivate = updateUserDTO.IsProfilePrivate == default ? user.IsProfilePrivate : updateUserDTO.IsProfilePrivate;
            user.Password = updateUserDTO.Password == "string" ? user.Password : updateUserDTO.Password;
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
                Password = user.Password
            };
        }
        public async Task<(UserDTO,UserDTO)> FollowSomeoneAsync(string user1Id, string user2Id)
        {
            User? user1 = await _userQueryRepository.Table.Include(u => u.Follows).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(user1Id)));
            User? user2 = await _userQueryRepository.Table.Include(u => u.Followers).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(user2Id)));
            user1.Follows.Add(user2);

            user2.Followers.Add(user1);
            _userCommandRepository.Update(user1);
            await _userCommandRepository.SaveAsync();
            _userCommandRepository.Update(user2);
            await _userCommandRepository.SaveAsync();
            return (new()
            {
                Id = userDataProtector.Protect(user1.Id.ToString()),
                Name = user1.Name,
                Surname = user1.Surname,
                NickName = user1.NickName,
            },
            new()
            {
                Id = userDataProtector.Protect(user2.Id.ToString()),
                Name = user2.Name,
                Surname = user2.Surname,
                NickName = user2.NickName,
            }
            );
        }

        public async Task<(List<GetAllPostsDTO>,  int totalCount)> GetUsersPostsAsync(string id)
        {
            User? user = await _userQueryRepository.Table.Include(u => u.Posts).ThenInclude(c => c.Comments).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            return new(user?.Posts.Select(p => new GetAllPostsDTO()
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
                    LikeCount=c.LikeCount
                }).ToList() ?? new List<CommentDTO>()
            }).ToList() ?? new List<GetAllPostsDTO>(),user.Posts.Count());
        }

        public async Task<(List<GetAllCommentsDTO>, int totalCount)> GetUsersCommentsAsync(string id)
        {
            User? user = await _userQueryRepository.Table.Include(c => c.Comments).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(id)));
            return new(user.Comments.Select(c=>new GetAllCommentsDTO()
            {
                UserId = userDataProtector.Protect(c.UserId.ToString()),
                PostId = postDataProtector.Protect(c.PostID.ToString()), 
                Id = commentDataProtector.Protect(c.Id.ToString()),
                Content = c.Content,
                LikeCount = c.LikeCount
            }).ToList() ?? new List<GetAllCommentsDTO>(), user.Comments.Count());
        }
    }
}

