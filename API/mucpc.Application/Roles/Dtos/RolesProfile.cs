using AutoMapper;
using mucpc.Domain.Entities;


namespace mucpc.Application.Roles.Dtos;

public class RolesProfile : Profile
{
    public RolesProfile()
    {
        CreateMap<Role, RoleDto>();
        CreateMap<CreateRoleDto, Role>();
    }
}
