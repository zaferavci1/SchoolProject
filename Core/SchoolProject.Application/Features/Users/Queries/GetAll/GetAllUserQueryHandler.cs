using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetAll
{
	public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, IDataResult<GetAllUserQueryResponse>>
	{
        private IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IDataResult<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllUsersDTO> user, int totalCount) data = await _userService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllUserQueryResponse>("Veriler Listelendi.", new GetAllUserQueryResponse()
            {
                TotalUserCount = data.totalCount,
                UsersDTOs = data.user
            });
        }
    }
}

