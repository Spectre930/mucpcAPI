using AutoMapper;
using MediatR;
using mucpc.Application.Students.Dtos;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Students.Queries.GetStudentById;

public class GetStudentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await unitOfWork.Students.GetFirstOrDefaultAsync(x => x.User.Id == request.Id, ["User"]);
        return mapper.Map<StudentDto>(student);
    }
}
