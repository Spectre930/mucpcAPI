using AutoMapper;
using MediatR;
using mucpc.Application.Forms.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetEvaluationForm;

public class GetEvaluationFormQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetEvaluationFormQuery, FormDto>
{
    public async Task<FormDto> Handle(GetEvaluationFormQuery request, CancellationToken cancellationToken)
    {
        var evForm = await unitOfWork.Forms.GetFirstOrDefaultAsync(x => x.WorkShopId == request.workshopId && x.EvaluationForm) ?? throw new Exception("No Evaluation Form Found!");
        return mapper.Map<FormDto>(evForm);
    }
}
