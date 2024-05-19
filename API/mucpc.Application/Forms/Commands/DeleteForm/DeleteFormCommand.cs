using MediatR;

namespace mucpc.Application.Forms.Commands.DeleteForm;

public class DeleteFormCommand(long id) : IRequest
{
    public long Id { get; set; } = id;
}
