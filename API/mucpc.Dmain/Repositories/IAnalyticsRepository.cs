using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IAnalyticsRepository
{
    Task<List<int?>> GetAcademicYears();
    Task<Instructor> GetHighestRatedInstructor();
    Task<Instructor> GetHighestRatedInstructorInAnAcademicYear(int year);
    Task<WorkShop> GetHighestRatedWorkshop();
    Task<WorkShop> GetHighestRatedWorkshopInAnAcademicYear(int year);
    Task<int> NumberOfInstructors();
    Task<int> NumberOfStudents();
    Task<int> NumberOfWorkShops();
    Task<int> NumberOfWorkShopsInAnAcademicYear(int year);
}