using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Students.Commands.AddStudent;

public class AddStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddStudentCommand>
{
    public async Task Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = mapper.Map<Student>(request);
        await unitOfWork.Students.AddStudent(student);
    }
}
