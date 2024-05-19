using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.Analytics.Queries.GetHighestRatedWorkshop;
public class GetHighestRatedWorkshopQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetHighestRatedWorkshopQuery, WorkshopDto>
{
    public async Task<WorkshopDto> Handle(GetHighestRatedWorkshopQuery request, CancellationToken cancellationToken)
    {
        var workshop = await unitOfWork.Analytics.GetHighestRatedWorkshop();
        return mapper.Map<WorkshopDto>(workshop);
    }
}

