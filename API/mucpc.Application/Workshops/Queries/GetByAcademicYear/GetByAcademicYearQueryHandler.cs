using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetByAcademicYear;

public class GetByAcademicYearQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetByAcademicYearQuery, IEnumerable<WorkshopDto>>
{
    public async Task<IEnumerable<WorkshopDto>> Handle(GetByAcademicYearQuery request, CancellationToken cancellationToken)
    {
        var workshops = await unitOfWork.Workshops.GetWorkshopsOfAnAcedemicYear(request.AcademicYear);
        return mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
}
