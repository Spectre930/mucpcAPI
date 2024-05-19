
using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.Dtos;

public class WorkshopsProfile : Profile
{
    public WorkshopsProfile()
    {
        CreateMap<WorkShop, WorkshopDto>();
        CreateMap<WorkshopDto, WorkShop>();
        CreateMap<CreateWorkshopDto, WorkShop>();
    }
}
