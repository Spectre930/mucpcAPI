
using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetWorkshopsOfRecentSemester;

public class GetWorkshopsOfRecentSemesterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetWorkshopsOfRecentSemesterQuery, IEnumerable<WorkshopDto>>
{

    public async Task<IEnumerable<WorkshopDto>> Handle(GetWorkshopsOfRecentSemesterQuery request, CancellationToken cancellationToken)
    {
        var workshops = await unitOfWork.Workshops.GetWorkshopsOfRecentSemester();
        return mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
}