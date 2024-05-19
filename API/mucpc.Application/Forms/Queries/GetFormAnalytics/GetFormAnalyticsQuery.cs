using MediatR;
using mucpc.Dmain.DTO.FormAnalytics;

namespace mucpc.Application.Forms.Queries.GetFormAnalytics;

public class GetFormAnalyticsQuery(long id) : IRequest<FormAnalytics>
{
    public long Id { get; set; } = id;
}
