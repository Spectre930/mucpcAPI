using MediatR;

namespace mucpc.Application.Analytics.Queries.NumberOfWorkShopsInAnAcademicYear;

public class NumberOfWorkShopsInAnAcademicYearQuery(int year) : IRequest<int>
{
    public int Year { get; set; } = year;
}
