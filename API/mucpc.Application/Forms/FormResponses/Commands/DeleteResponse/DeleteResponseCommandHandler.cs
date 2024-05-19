using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.FormResponses.Commands.DeleteResponse;

public class DeleteResponseCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteResponseCommand>
{
    public async Task Handle(DeleteResponseCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.FormResponses.DeleteResponse(request.Id);
    }
}
