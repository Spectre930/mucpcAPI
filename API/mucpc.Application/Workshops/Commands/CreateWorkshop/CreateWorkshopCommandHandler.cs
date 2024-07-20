using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.Commands.CreateWorkshop;

public class CreateWorkshopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateWorkshopCommand>
{
    public async Task Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = mapper.Map<WorkShop>(request);
        await unitOfWork.Workshops.AddWorkShop(workshop);
    }
}
