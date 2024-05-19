using mucpc.Application.Students.Dtos;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Students;

public interface IStudnetsService
{
    Task AddStudent(CreateStudentDto dto);
    Task DeleteStudent(long id);
    Task<IEnumerable<StudentDto>> GetAll();
    Task<StudentDto> GetById(long id);
    Task<IEnumerable<WorkshopDto>> GetWorkshops(long studentId);
    Task UpdateStudent(StudentDto student);
}