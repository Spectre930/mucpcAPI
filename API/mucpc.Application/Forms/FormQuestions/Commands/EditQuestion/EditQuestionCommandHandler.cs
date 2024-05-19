
using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.FormQuestions.Commands.EditQuestion;

public class EditQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<EditQuestionCommand>
{
    public async Task Handle(EditQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await unitOfWork.FormQuestions.GetById(request.Id);
        mapper.Map(request, question);

        await unitOfWork.FormQuestions.EditQuestion(question);
    }
}
