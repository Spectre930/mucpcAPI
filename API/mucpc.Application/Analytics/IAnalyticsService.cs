using mucpc.Application.Instructors.Dtos;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Analytics;

public interface IAnalyticsService
{
    Task<List<int?>> GetAcademicYears();
    Task<InstructorDto> GetHighestRatedInstructor();
    Task<InstructorDto> GetHighestRatedInstructorInAnAcademicYear(int year);
    Task<WorkshopDto> GetHighestRatedWorkshop();
    Task<WorkshopDto> GetHighestRatedWorkshopInAnAcademicYear(int year);
    Task<int> NumberOfInstructors();
    Task<int> NumberOfStudents();
    Task<int> NumberOfWorkShops();
    Task<int> NumberOfWorkShopsInAnAcademicYear(int year);
}