using AutoMapper;
using mucpc.Application.Workshops.Commands.CreateWorkshop;
using mucpc.Application.Workshops.Commands.UpdateWorkShop;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.Dtos;

public class WorkshopsProfile : Profile
{
    public WorkshopsProfile()
    {
        CreateMap<WorkShop, WorkshopDto>();
        CreateMap<WorkshopDto, WorkShop>();
        CreateMap<CreateWorkshopCommand, WorkShop>();
        CreateMap<UpdateWorkShopCommand, WorkShop>();
    }
}
