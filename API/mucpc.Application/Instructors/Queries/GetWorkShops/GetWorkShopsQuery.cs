using MediatR;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Instructors.Queries.GetWorkShops;

public class GetWorkShopsQuery(long instructorId) : IRequest<IEnumerable<WorkshopDto>>
{
    public long InstructorId { get; set; } = instructorId;
}
