using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.RegisterRequests.Commands.AddRegisterRequest;

public class AddRegisterRequestCommandHandler(IUnitOfWork unitOfWork, IMapper Mapper) : IRequestHandler<AddRegisterRequestCommand>
{
    public async Task Handle(AddRegisterRequestCommand request, CancellationToken cancellationToken)
    {
        long responseId;
        try
        {
            var formrEsponse = Mapper.Map<FormResponse>(request.Request.FormResponse);
            responseId = await unitOfWork.FormResponses.AddResponse(formrEsponse);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        var registerRequest = Mapper.Map<RegisterRequest>(request.Request);
        registerRequest.FormResponseId = responseId;
        registerRequest.WorkShopId = request.workshopId;

        try
        {
            await unitOfWork.RegisterRequests.AddRegisterRequest(registerRequest);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
