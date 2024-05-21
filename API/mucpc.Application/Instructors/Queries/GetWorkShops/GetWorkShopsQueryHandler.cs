using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Instructors.Queries.GetWorkShops;

public class GetWorkShopsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetWorkShopsQuery, IEnumerable<WorkshopDto>>
{
    public async Task<IEnumerable<WorkshopDto>> Handle(GetWorkShopsQuery request, CancellationToken cancellationToken)
    {
        var workshops = await unitOfWork.Instructors.GetWorkShops(request.InstructorId);
        return mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
}
