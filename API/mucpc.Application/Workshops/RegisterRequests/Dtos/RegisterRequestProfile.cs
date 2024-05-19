using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.RegisterRequests.Dtos;

public class RegisterRequestProfile : Profile
{
    public RegisterRequestProfile()
    {
        CreateMap<RegisterRequest, RegisterRequestDto>();
        CreateMap<CreateRegisterRequestDto, RegisterRequest>();
    }
}
