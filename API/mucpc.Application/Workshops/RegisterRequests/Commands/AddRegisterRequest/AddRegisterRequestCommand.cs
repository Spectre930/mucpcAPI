using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Application.Workshops.RegisterRequests.Commands.AddRegisterRequest;

public record AddRegisterRequestCommand(CreateRegisterRequestDto Request, long workshopId) : IRequest;
