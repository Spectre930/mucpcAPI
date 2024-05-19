using AutoMapper;
using MediatR;
using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.FormQuestions.Queries.GetQuestionsByFormId;

public class GetQuestionsByFormIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetQuestionsByFormIdQuery, IEnumerable<FormQuestionDto>>
{
    public async Task<IEnumerable<FormQuestionDto>> Handle(GetQuestionsByFormIdQuery request, CancellationToken cancellationToken)
    {
        var questions = await unitOfWork.FormQuestions.GetQuestionsByFormId(request.FormId);
        return mapper.Map<IEnumerable<FormQuestionDto>>(questions);
    }
}
