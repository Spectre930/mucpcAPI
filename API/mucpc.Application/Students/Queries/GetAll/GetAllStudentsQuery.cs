using MediatR;
using mucpc.Application.Students.Dtos;

namespace mucpc.Application.Students.Queries.GetAll;
public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
{

}

