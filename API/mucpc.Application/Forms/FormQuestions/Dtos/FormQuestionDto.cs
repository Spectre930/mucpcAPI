using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormQuestions.Responses.Dtos;


namespace mucpc.Application.Forms.FormQuestions.Dtos;

public class FormQuestionDto
{
    public long Id { get; set; }
    public string Question { get; set; }
    public string Type { get; set; }
    public string? Options { get; set; }
    public long FormId { get; set; }
    public FormDto Form { get; set; }

    public ICollection<QuestionResponseDto> QuestionResponses { get; set; }
}
