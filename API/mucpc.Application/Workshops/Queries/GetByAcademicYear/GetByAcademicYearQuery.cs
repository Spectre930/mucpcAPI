using MediatR;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Workshops.Queries.GetByAcademicYear;

public class GetByAcademicYearQuery(int academicYear) : IRequest<IEnumerable<WorkshopDto>>
{
    public int AcademicYear { get; set; } = academicYear;
}

