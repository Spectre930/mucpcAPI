using AutoMapper;
using mucpc.Application.AppUsers.Admins.Commands.CreateAdmin;
using mucpc.Application.AppUsers.Admins.Commands.UpdateAdmin;
using mucpc.Domain.Entities;

namespace mucpc.Application.AppUsers.Dtos;

public class AppUserProfiles : Profile
{
    public AppUserProfiles()
    {
        CreateMap<AppUser, AppUserDto>();
        CreateMap<AppUserDto, AppUser>();
        CreateMap<CreateAppUserCommand, AppUser>();
        CreateMap<UpdateAppUserCommand, AppUser>();
    }

}
