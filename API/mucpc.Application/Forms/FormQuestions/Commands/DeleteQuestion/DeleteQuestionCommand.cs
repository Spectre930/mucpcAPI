using MediatR;

namespace mucpc.Application.Forms.FormQuestions.Commands.DeleteQuestion;

public class DeleteQuestionCommand(long id) : IRequest
{
    public long Id { get; set; } = id;

}
