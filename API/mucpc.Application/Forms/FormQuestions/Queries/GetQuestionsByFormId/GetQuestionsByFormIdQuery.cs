using MediatR;
using mucpc.Application.Forms.FormQuestions.Dtos;

namespace mucpc.Application.Forms.FormQuestions.Queries.GetQuestionsByFormId;

public class GetQuestionsByFormIdQuery(long formId) : IRequest<IEnumerable<FormQuestionDto>>
{
    public long FormId { get; set; } = formId;
}
