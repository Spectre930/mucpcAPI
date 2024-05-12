using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;

namespace mucpc.Application.Forms.FormQuestions.Responses.Dtos;

public class QuestionResponseDto
{
    public long FormResponseId { get; set; }
    public FormResponseDto FormResponse { get; set; }


    public long FormQuestionId { get; set; }
    public FormQuestionDto FormQuestion { get; set; }

    public string Response { get; set; }
}
