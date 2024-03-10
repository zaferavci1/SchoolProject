using System;
using SchoolProject.Application.Features.PublicProfiles.DTOs;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface IPublicProfileService
	{
        Task<(List<GetAllPublicProfilesDTO>, int totalCount)> GetAllAsync(int page, int size);

        Task<GetByIdPublicProfileDTO> GetByIdAsync(string id);
        Task<PublicProfilesDTO> AddAsync(AddPublicProfilesDTO addPublicProfilesDTO);
        Task<PublicProfilesDTO> UpdateAsync(UpdatePublicProfileDTO updatePublicProfileDTO);
        Task<PublicProfilesDTO> DeleteAsync(int id);
    }
}

