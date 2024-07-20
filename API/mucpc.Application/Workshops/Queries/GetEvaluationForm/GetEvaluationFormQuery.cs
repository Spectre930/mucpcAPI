using MediatR;
using mucpc.Application.Forms.Dtos;

namespace mucpc.Application.Workshops.Queries.GetEvaluationForm;

public class GetEvaluationFormQuery(long id) : IRequest<FormDto>
{
    public long workshopId { get; set; } = id;
}
