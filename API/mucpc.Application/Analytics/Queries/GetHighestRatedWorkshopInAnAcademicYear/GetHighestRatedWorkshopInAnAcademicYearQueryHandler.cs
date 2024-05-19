using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.Analytics.Queries.GetHighestRatedWorkshopInAnAcademicYear;

public class GetHighestRatedWorkshopInAnAcademicYearQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetHighestRatedWorkshopInAnAcademicYearQuery, WorkshopDto>
{


    public async Task<WorkshopDto> Handle(GetHighestRatedWorkshopInAnAcademicYearQuery request, CancellationToken cancellationToken)
    {
        var workshop = await unitOfWork.Analytics.GetHighestRatedWorkshopInAnAcademicYear(request.Year);
        return mapper.Map<WorkshopDto>(workshop);
    }
}

