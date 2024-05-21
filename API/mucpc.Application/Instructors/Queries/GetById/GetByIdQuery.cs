using MediatR;
using mucpc.Application.Instructors.Dtos;

namespace mucpc.Application.Instructors.Queries.GetById;

public class GetByIdQuery(long id) : IRequest<InstructorDto>
{
    public long Id { get; set; } = id;
}
