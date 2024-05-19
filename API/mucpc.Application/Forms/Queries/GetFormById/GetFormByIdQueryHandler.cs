using AutoMapper;
using MediatR;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.Queries.GetFormById;

public class GetFormByIdQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetFormByIdQuery, FormVm>
{
    public async Task<FormVm> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        var form = await _unitOfWork.Forms.GetById(request.Id);
        var questions = await _unitOfWork.FormQuestions.GetQuestionsByFormId(request.Id);
        var questionsDto = _mapper.Map<List<FormQuestionDto>>(questions);
        var formVm = new FormVm
        {
            Form = _mapper.Map<FormDto>(form),
            Questions = questionsDto
        };

        return formVm;
    }
}

