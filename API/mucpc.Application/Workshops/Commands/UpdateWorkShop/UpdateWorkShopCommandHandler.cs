using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Commands.UpdateWorkShop;
public class UpdateWorkShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateWorkShopCommand>
{
    public async Task Handle(UpdateWorkShopCommand request, CancellationToken cancellationToken)
    {
        var workshop = await unitOfWork.Workshops.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("workshop not found!");

        mapper.Map(request, workshop);

        await unitOfWork.Workshops.UpdateWorkShop(workshop);
    }
}

