using MediatR;

namespace mucpc.Application.Forms.FormQuestions.Commands.EditQuestion;

public class EditQuestionCommand : IRequest
{
    public long Id { get; set; }
    public string Question { get; set; }
    public string Type { get; set; }
    public string[]? Options { get; set; }
}
