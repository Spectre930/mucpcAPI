using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await unitOfWork.Students.GetById(request.user.Id);

        mapper.Map(request, student);

        await unitOfWork.Students.UpdateStudent(student);
    }
}
