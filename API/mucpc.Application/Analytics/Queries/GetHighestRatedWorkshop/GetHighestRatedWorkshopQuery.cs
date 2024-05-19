using MediatR;
using mucpc.Application.Workshops.Dtos;


namespace mucpc.Application.Analytics.Queries.GetHighestRatedWorkshop;

public class GetHighestRatedWorkshopQuery : IRequest<WorkshopDto>
{
}
