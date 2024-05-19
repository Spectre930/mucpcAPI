using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.FormQuestions.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteQuestionCommand>
{
    public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.FormQuestions.DeleteQuestion(request.Id);
    }
}
