using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, IDataResult<GetByIdUserDTO>>
    {
        private IUserService _userService;

        public GetByIdUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IDataResult<GetByIdUserDTO>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdUserDTO getByIdUserDTO = await _userService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdUserDTO>("Kullanıcı Getirildi.", getByIdUserDTO);
        }
    }
}

