using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Dmain.DTO.FormAnalytics;

namespace mucpc.Application.Forms
{
    internal interface IFormService
    {
        Task AddForm(CreateFormDto dto);
        Task DeleteForm(long id);
        Task<FormVm> GetById(long id);
        Task<FormAnalytics> GetFormAnalytics(long id);
        Task<IEnumerable<FormResponseDto>> GetFormResponses(long id);
        Task<IEnumerable<FormVm>> GetForms();
        Task UpdateForm(FormDto dto);
    }
}