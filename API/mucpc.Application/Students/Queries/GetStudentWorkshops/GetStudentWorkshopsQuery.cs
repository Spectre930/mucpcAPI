using MediatR;
using mucpc.Application.Workshops.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Students.Queries.GetStudentWorkshops;

public class GetStudentWorkshopsQuery(long id) : IRequest<IEnumerable<WorkshopDto>>
{
    public long Id { get; set; } = id;
}

