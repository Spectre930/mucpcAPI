using AutoMapper;
using MediatR;
using mucpc.Application.Students.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Students.Queries.GetAll;

public class GetAllStudentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
{

    public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await unitOfWork.Students.GetAllAsync(["User"]);
        return mapper.Map<IEnumerable<StudentDto>>(students);
    }
}

