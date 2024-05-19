using AutoMapper;
using MediatR;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.Queries.GetAllForms;

public class GetAllFormsQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetAllFormsQuery, IEnumerable<FormVm>>
{
    public async Task<IEnumerable<FormVm>> Handle(GetAllFormsQuery request, CancellationToken cancellationToken)
    {
        var forms = await _unitOfWork.Forms.GetAllAsync();
        var dto = _mapper.Map<IEnumerable<FormDto>>(forms);
        var formVms = new List<FormVm>();

        foreach (var form in dto)
        {
            var questions = await _unitOfWork.FormQuestions.GetQuestionsByFormId(form.Id);
            var questionsDto = _mapper.Map<List<FormQuestionDto>>(questions);
            var formVm = new FormVm
            {
                Form = form,
                Questions = questionsDto
            };
            formVms.Add(formVm);
        }

        return formVms;
    }
}
