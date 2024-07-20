using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.Students.Queries.GetStudentWorkshops;

public class GetStudentWorkshopsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetStudentWorkshopsQuery, IEnumerable<WorkshopDto>>
{
    public async Task<IEnumerable<WorkshopDto>> Handle(GetStudentWorkshopsQuery request, CancellationToken cancellationToken)
    {
        var workshops = await unitOfWork.Students.GetWorkshops(request.Id);
        return mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
}
