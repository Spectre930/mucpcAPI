using mucpc.Dmain.DTO.FormAnalytics;
using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IFormRepository : IRepository<Form>
{
    Task<Form> GetById(long id);
    Task<long> AddForm(Form dto);
    Task UpdateForm(Form form);
    Task DeleteForm(long id);
    Task<FormAnalytics> GetFormAnalytics(long id);
    Task<IEnumerable<FormResponse>> GetFormResponses(long id);

}
