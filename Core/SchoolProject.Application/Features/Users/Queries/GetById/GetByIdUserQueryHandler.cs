using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, IDataResult<GetByIdUserDTO>>
    {
        private IUserService _userService;
        UserBusinessRules _userBusinessRules;

        public GetByIdUserQueryHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<GetByIdUserDTO>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.Id);
            await _userBusinessRules.IsUserActiveAsync(request.Id);

            GetByIdUserDTO getByIdUserDTO = await _userService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdUserDTO>("Kullanıcı Getirildi.", getByIdUserDTO);
        }
    }
}

