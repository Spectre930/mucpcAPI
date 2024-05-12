using AutoMapper;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormQuestions;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Dmain.DTO.FormAnalytics;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;


namespace mucpc.Application.Forms;

internal class FormService(IFormRepository _formRepository,
    IFormQuestionService _FQService,
    IMapper _mapper) : IFormService
{
    public async Task<IEnumerable<FormVm>> GetForms()
    {
        var forms = await _formRepository.GetAllAsync();
        var dto = _mapper.Map<IEnumerable<FormDto>>(forms);
        var formVms = new List<FormVm>();

        foreach (var form in dto)
        {
            var questions = await _FQService.GetQuestionsByFormId(form.Id);
            var formVm = new FormVm
            {
                Form = form,
                Questions = questions
            };
            formVms.Add(formVm);
        }

        return formVms;
    }
    public async Task<FormVm> GetById(long id)
    {
        var form = await _formRepository.GetById(id);

        var questions = await _FQService.GetQuestionsByFormId(form.Id);

        var formVm = new FormVm
        {
            Form = _mapper.Map<FormDto>(form),
            Questions = questions
        };

        return formVm;
    }
    public async Task AddForm(CreateFormDto dto)
    {
        var form = _mapper.Map<Form>(dto);
        var formId = await _formRepository.AddForm(form);
        foreach (var question in dto.Questions)
        {
            question.FormId = formId;
            await _FQService.AddQuestion(question);
        }
    }
    public async Task UpdateForm(FormDto dto)
    {
        var form = _mapper.Map<Form>(dto);
        await _formRepository.UpdateForm(form);
    }
    public async Task DeleteForm(long id)
    {
        await _formRepository.DeleteForm(id);
    }
    public async Task<FormAnalytics> GetFormAnalytics(long id)
    {
        return await _formRepository.GetFormAnalytics(id);
    }
    public async Task<IEnumerable<FormResponseDto>> GetFormResponses(long id)
    {
        var responses = await _formRepository.GetFormResponses(id);
        return _mapper.Map<IEnumerable<FormResponseDto>>(responses);
    }
}
