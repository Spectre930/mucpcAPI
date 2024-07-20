using MediatR;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Workshops.Queries.GetWorkshopsOfRecentSemester;

public class GetWorkshopsOfRecentSemesterQuery : IRequest<IEnumerable<WorkshopDto>>
{
}
