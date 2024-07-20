using MediatR;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Workshops.Queries.GetWorkshopById;

public class GetWorkshopByIdQuery(long id) : IRequest<WorkshopDto>
{
    public long Id { get; set; } = id;
}
