using MediatR;
using mucpc.Dmain.DTO.FormAnalytics;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.Forms.Queries.GetFormAnalytics;

public class GetFormAnalyticsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetFormAnalyticsQuery, FormAnalytics>
{
    public async Task<FormAnalytics> Handle(GetFormAnalyticsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Forms.GetFormAnalytics(request.Id);
    }
}
