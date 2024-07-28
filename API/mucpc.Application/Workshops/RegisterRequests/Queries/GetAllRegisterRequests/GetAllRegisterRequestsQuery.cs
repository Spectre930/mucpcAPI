using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Application.Workshops.RegisterRequests.Queries.GetAllRegisterRequests;

public record GetAllRegisterRequestsQuery() : IRequest<List<RegisterRequestDto>>;
