using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetAllWorkshops;

public class GetAllWorkshopsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllWorkshopsQuery, IEnumerable<WorkshopDto>>
{
    public async Task<IEnumerable<WorkshopDto>> Handle(GetAllWorkshopsQuery request, CancellationToken cancellationToken)
    {
        var workshops = await unitOfWork.Workshops.GetAllAsync();
        return mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
}
