using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.Commands.CreateForm;

public class CreateFormCommandHandler(IUnitOfWork unitOfWork, IMapper _mapper) : IRequestHandler<CreateFormCommand>
{
    public async Task Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = _mapper.Map<Form>(request);

        var formId = await unitOfWork.Forms.AddForm(form);
        foreach (var dto in request.Questions)
        {
            var question = _mapper.Map<FormQuestion>(dto);
            question.FormId = formId;
            await unitOfWork.FormQuestions.AddQuestion(question);
        }
        await unitOfWork.SaveAsync();
    }
}
