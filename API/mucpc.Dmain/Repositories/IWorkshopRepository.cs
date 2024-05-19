using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IWorkshopRepository : IRepository<WorkShop>
{
    Task AddWorkShop(WorkShop dto);
    (int academicYear, string semester) GetRecent();
    Task UpdateWorkShop(WorkShop workShop);
    int GetLastWorkshopNumber(int academicYear, string semester);
    Task<List<string>> GetRegisteredEmails(long WorkShopId);
    Task<double?> GetWorkShopRating(long WorkShopId);
    Task<List<RegisterRequest>> GetRegisterRequests(long workshopId);
    Task<IEnumerable<WorkShop>> GetWorkshopsOfAnAcedemicYear(int academicYear);
    Task<IEnumerable<WorkShop>> GetWorkshopsOfRecentSemester();
    Task EvaluateWorkshop(long workshopId, FormResponse evaluation);
}
