using mucpc.Application.Forms.FormQuestions.Dtos;

namespace mucpc.Application.Forms.Dtos;

public class CreateFormDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long WorkShopId { get; set; }
    public bool RegistrationForm { get; set; }
    public bool EvaluationForm { get; set; }
    public List<CreateFormQuestionDto> Questions { get; set; }
}
