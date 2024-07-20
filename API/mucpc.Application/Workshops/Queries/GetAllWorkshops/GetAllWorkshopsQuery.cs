using MediatR;
using mucpc.Application.Workshops.Dtos;
namespace mucpc.Application.Workshops.Queries.GetAllWorkshops;

public class GetAllWorkshopsQuery : IRequest<IEnumerable<WorkshopDto>>
{
}
