using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.RegisterRequests.Commands.VerifyRequest;

public class VerifyRequestCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<VerifyRequestCommand>
{
    public async Task Handle(VerifyRequestCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.RegisterRequests.VerifyRequest(request.requestId, request.isAccepted);
    }
}
