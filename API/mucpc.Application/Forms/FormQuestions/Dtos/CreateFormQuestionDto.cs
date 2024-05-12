namespace mucpc.Application.Forms.FormQuestions.Dtos;

public class CreateFormQuestionDto
{
    public string Question { get; set; }
    public string Type { get; set; }
    public string[]? Options { get; set; }
    public long FormId { get; set; }
}
