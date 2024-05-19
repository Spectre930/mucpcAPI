using mucpc.Dmain.DTO;
using mucpc.Domain.Entities;


namespace mucpc.Dmain.Repositories;

public interface IInstructorRepository : IRepository<Instructor>
{
    Task AddInstructor(Instructor instructor);
    Task UpdateInstructor(Instructor instructor);
    Task DeleteInstructor(long id);
    Task<IEnumerable<WorkShop>> GetWorkShops(long InstructorId);
    Task<double?> GetInstructorRatingInAWorkShop(long WorkShopId);
    Task<double?> GetOverAllInstructorRating(long InstructorId);
}
