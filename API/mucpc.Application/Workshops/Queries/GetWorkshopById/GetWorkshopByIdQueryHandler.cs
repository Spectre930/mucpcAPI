using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetWorkshopById;

public class GetWorkshopByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetWorkshopByIdQuery, WorkshopDto>
{

    public async Task<WorkshopDto> Handle(GetWorkshopByIdQuery request, CancellationToken cancellationToken)
    {
        var workshop = await unitOfWork.Workshops.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("workshop not found!");
        return mapper.Map<WorkshopDto>(workshop);
    }
}

