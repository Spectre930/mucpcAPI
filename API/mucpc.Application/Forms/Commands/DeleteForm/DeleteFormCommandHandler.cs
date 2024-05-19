
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.Commands.DeleteForm;

public class DeleteFormCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteFormCommand>
{
    public async Task Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.Forms.DeleteForm(request.Id);
    }
}
