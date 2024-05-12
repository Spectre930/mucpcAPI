using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormQuestions.Responses.Dtos;
using mucpc.Application.Students.Dtos;



namespace mucpc.Application.Forms.FormResponses.Dtos;

public class FormResponseDto
{
    public long Id { get; set; }
    public long FormId { get; set; }
    public FormDto Form { get; set; }
    public long? StudentId { get; set; }
    public StudentDto? Student { get; set; }
    public ICollection<QuestionResponseDto> QuestionsResponses { get; set; }
}
