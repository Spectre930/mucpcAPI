using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormResponses.Commands.AddResponse;

public class AddResponseCommandHandler(IUnitOfWork _unitOfWork,
    IMapper _mapper)
    : IRequestHandler<AddResponseCommand, long>
{
    public async Task<long> Handle(AddResponseCommand request, CancellationToken cancellationToken)
    {
        var response = _mapper.Map<FormResponse>(request);
        return await _unitOfWork.FormResponses.AddResponse(response);
    }
}

