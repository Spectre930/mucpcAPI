using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IFormResponseRepository
{
    public Task<long> AddResponse(FormResponse formResponse);
    public Task DeleteResponse(long ResponseId);
    public Task<FormResponse> GetResponseById(long ResponseId);

}
