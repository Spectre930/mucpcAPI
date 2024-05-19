
using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IRegisterRequestRepository : IRepository<RegisterRequest>
{
    Task AddRegisterRequest(RegisterRequest request);
    Task VerifyRequest(long requestId, bool isAccepted);
}
