using MediatR;
using mucpc.Application.Instructors.Dtos;


namespace mucpc.Application.Analytics.Queries.GetHighestRatedInstructorInAnAcademicYear;

public class GetHighestRatedInstructorInAnAcademicYearQuery(int year) : IRequest<InstructorDto>
{
    public int Year { get; set; } = year;
}
