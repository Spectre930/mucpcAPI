using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Instructors.Commands.DeleteInstructor;

public class DeleteInstructorCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteInstructorCommand>
{
    public async Task Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.Instructors.DeleteInstructor(request.Id);
    }
}
