using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Application.Workshops.RegisterRequests.Queries.GetRegisterRequestById;

public record GetRegisterRequestByIdQuery(long Id) : IRequest<RegisterRequestDto>;
