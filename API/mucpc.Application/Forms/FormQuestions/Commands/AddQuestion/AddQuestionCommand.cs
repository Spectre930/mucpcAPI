using MediatR;
namespace mucpc.Application.Forms.FormQuestions.Commands.AddQuestion;

public class AddQuestionCommand : IRequest
{
    public string Question { get; set; }
    public string Type { get; set; }
    public string[]? Options { get; set; }
    public long FormId { get; set; }
}
