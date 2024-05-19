using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormQuestions.Commands.AddQuestion;

public class AddQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddQuestionCommand>
{
    public async Task Handle(AddQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<FormQuestion>(request);
        await unitOfWork.FormQuestions.AddQuestion(question);
    }
}