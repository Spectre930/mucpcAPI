using MediatR;
using mucpc.Application.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Students.Queries.GetStudentById;

public class GetStudentByIdQuery(long id) : IRequest<StudentDto>
{
    public long Id { get; set; } = id;

}

