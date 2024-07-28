using MediatR;

namespace mucpc.Application.Workshops.RegisterRequests.Commands.VerifyRequest;

public record VerifyRequestCommand(long requestId, bool isAccepted) : IRequest;

