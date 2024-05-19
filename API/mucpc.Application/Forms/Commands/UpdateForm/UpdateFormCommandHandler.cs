using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.Commands.UpdateForm;

public class UpdateFormCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateFormCommand>
{
    public async Task Handle(UpdateFormCommand request, CancellationToken cancellationToken)
    {
        if (request.EvaluationForm & request.RegistrationForm || !request.RegistrationForm & !request.EvaluationForm)
        {
            throw new Exception("Form must be either Evaluation or Registration");
        }

        var form = await unitOfWork.Forms
            .GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("form not found!");

        mapper.Map(request, form);

        await unitOfWork.Forms.UpdateForm(form);
    }
}
