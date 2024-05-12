using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Domain.Entities;


namespace mucpc.Application.Forms.Dtos;

public class FormDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool RegistrationForm { get; set; }
    public bool EvaluationForm { get; set; }
    public long WorkShopId { get; set; }
    public WorkshopDto WorkShop { get; set; }
    public ICollection<FormQuestionDto> FormQuestions { get; set; }
    public ICollection<FormResponseDto> FormResponses { get; set; }
}
