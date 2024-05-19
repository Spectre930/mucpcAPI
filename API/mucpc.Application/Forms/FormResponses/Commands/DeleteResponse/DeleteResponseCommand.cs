using MediatR;

namespace mucpc.Application.Forms.FormResponses.Commands.DeleteResponse;

public class DeleteResponseCommand(long id) : IRequest
{
    public long Id { get; set; } = id;
}
