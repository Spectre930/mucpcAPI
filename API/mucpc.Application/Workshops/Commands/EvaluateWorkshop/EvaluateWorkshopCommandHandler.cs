using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.Commands.EvaluateWorkshop;

public class EvaluateWorkshopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<EvaluateWorkshopCommand>
{
    public async Task Handle(EvaluateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var evaluation = mapper.Map<FormResponse>(request.evaluation);
        await unitOfWork.Workshops.EvaluateWorkshop(request.workshopId, evaluation);
    }
}
