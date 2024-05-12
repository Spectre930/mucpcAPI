

using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.AppUsers.Dtos;

public class AppUserProfiles : Profile
{
    public AppUserProfiles()
    {
        CreateMap<AppUser, AppUserDto>();
        CreateMap<CreateAppUserDto, AppUser>();
    }

}
