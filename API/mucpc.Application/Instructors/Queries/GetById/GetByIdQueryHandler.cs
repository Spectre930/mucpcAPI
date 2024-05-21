using AutoMapper;
using MediatR;
using mucpc.Application.Instructors.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Instructors.Queries.GetById;

public class GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper _mapper) : IRequestHandler<GetByIdQuery, InstructorDto>
{
    public async Task<InstructorDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var instructor = await unitOfWork.Instructors.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("instructor not found!");

        return _mapper.Map<InstructorDto>(instructor);
    }
}
