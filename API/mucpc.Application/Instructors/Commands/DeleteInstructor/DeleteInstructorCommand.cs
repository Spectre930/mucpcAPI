using MediatR;

namespace mucpc.Application.Instructors.Commands.DeleteInstructor;

public class DeleteInstructorCommand(long InstructorId) : IRequest
{
    public long Id { get; set; } = InstructorId;
}



