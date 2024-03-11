

using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetAll
{
	public class GetAllPublicProfileQueryRequest : IRequest<IDataResult<GetAlllPublicProfileQueryResponse>>
	{
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

