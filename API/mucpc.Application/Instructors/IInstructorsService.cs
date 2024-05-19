using mucpc.Application.Instructors.Dtos;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Instructors;

public interface IInstructorsService
{
    Task<IEnumerable<InstructorDto>> GetAll();
    Task<InstructorDto> GetById(long id);
    Task AddInstructor(CreateInstructorDto dto);
    Task UpdateInstructor(InstructorDto instructor);
    Task DeleteInstructor(long id);
    Task<IEnumerable<WorkshopDto>> GetWorkShops(long InstructorId);
    Task<double?> GetInstructorRatingInAWorkShop(long WorkShopId);
    Task<double?> GetOverAllInstructorRating(long InstructorId);
}
