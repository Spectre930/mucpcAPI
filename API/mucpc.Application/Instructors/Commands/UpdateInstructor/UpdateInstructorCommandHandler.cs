using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Instructors.Commands.UpdateInstructor;

public class UpdateInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateInstructorCommand>
{
    public async Task Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = await unitOfWork.Instructors.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("Instructor not found!");

        mapper.Map(request, instructor);

        await unitOfWork.Instructors.UpdateInstructor(instructor);
    }
}
