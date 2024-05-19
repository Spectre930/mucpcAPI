using MediatR;
using mucpc.Application.Forms.FormQuestions.Commands.AddQuestion;


namespace mucpc.Application.Forms.FormResponses.Commands.AddResponse;
public class AddResponseCommand : IRequest<long>
{
    public long FormId { get; set; }
    public long StudentId { get; set; }
    public List<AddQuestionCommand> QuestionsResponses { get; set; }
}
