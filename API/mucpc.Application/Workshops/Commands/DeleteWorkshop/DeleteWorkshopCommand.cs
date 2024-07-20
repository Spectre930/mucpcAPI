
using MediatR;

namespace mucpc.Application.Workshops.Commands.DeleteWorkshop;

public class DeleteWorkshopCommand(long id) : IRequest
{
    public long Id { get; set; } = id;
}
