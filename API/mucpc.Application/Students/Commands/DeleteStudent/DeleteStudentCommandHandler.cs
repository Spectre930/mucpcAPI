using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Students.Commands.DeleteStudent;

public class DeleteStudentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteStudentCommand>
{

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await unitOfWork.Students.GetById(request.Id);

        await unitOfWork.Students.DeleteStudent(request.Id);

    }
}
