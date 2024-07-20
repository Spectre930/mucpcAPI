using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Commands.DeleteWorkshop;

public class DeleteWorkshopCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteWorkshopCommand>
{
    public async Task Handle(DeleteWorkshopCommand request, CancellationToken cancellationToken)
    {

        var workShop = await unitOfWork.Workshops.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("workshop not found!");
        unitOfWork.Workshops.Remove(workShop);
    }
}

