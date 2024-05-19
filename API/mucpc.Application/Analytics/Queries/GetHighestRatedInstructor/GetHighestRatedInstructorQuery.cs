using MediatR;
using mucpc.Application.Instructors.Dtos;

namespace mucpc.Application.Analytics.Queries.GetHighestRatedInstructor;

public class GetHighestRatedInstructorQuery : IRequest<InstructorDto>
{
}
