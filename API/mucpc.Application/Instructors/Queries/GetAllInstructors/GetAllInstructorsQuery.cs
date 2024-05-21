using MediatR;
using mucpc.Application.Instructors.Dtos;

namespace mucpc.Application.Instructors.Queries.GetAllInstructors;

public class GetAllInstructorsQuery : IRequest<IEnumerable<InstructorDto>>
{
}
