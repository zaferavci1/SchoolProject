using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Users.DTOs;

public class GetAllUserExceptUsersFolloweesDTO: IDTO
{
    public List<UserDTO> UserDtos { get; set; }
}