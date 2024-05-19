

using MediatR;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Analytics.Queries.GetHighestRatedWorkshopInAnAcademicYear;

public class GetHighestRatedWorkshopInAnAcademicYearQuery(int year) : IRequest<WorkshopDto>
{
    public int Year { get; set; } = year;

}
