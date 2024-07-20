using MediatR;

namespace mucpc.Application.Students.Commands.DeleteStudent;

public class DeleteStudentCommand(long id) : IRequest
{
    public long Id { get; set; } = id;
}
