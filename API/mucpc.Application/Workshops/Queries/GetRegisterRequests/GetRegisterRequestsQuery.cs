using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Application.Workshops.Queries.GetRegisterRequests;

public record GetRegisterRequestsQuery(long workshopId) : IRequest<List<RegisterRequestDto>>;
