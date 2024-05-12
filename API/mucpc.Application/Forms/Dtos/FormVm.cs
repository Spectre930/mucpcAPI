using mucpc.Application.Forms.FormQuestions.Dtos;

namespace mucpc.Application.Forms.Dtos;

public class FormVm
{
    public FormDto Form { get; set; }
    public List<FormQuestionDto> Questions { get; set; }
}
