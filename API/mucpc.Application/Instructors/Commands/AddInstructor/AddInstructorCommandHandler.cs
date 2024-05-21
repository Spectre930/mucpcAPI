using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Instructors.Commands.AddInstructor;

public class AddInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper _mapper) : IRequestHandler<AddInstructorCommand>
{
    public async Task Handle(AddInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = _mapper.Map<Instructor>(request);
        await unitOfWork.Instructors.AddInstructor(instructor);
    }
}
