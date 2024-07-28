using MediatR;
using mucpc.Application.Forms.FormResponses.Dtos;

namespace mucpc.Application.Workshops.Commands.EvaluateWorkshop;

public record EvaluateWorkshopCommand(long workshopId, FormResponseDto evaluation) : IRequest;
