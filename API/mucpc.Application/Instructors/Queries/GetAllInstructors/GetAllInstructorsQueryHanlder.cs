using AutoMapper;
using MediatR;
using mucpc.Application.Instructors.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Instructors.Queries.GetAllInstructors;

public class GetAllInstructorsQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllInstructorsQuery, IEnumerable<InstructorDto>>
{
    public async Task<IEnumerable<InstructorDto>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
    {
        var instructors = await unitOfWork.Instructors.GetAllAsync();
        return mapper.Map<IEnumerable<InstructorDto>>(instructors);
    }
}
