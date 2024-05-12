using System.ComponentModel.DataAnnotations;

namespace mucpc.Domain.Entities;

public class QuestionResponse
{

    [Required]
    public long FormResponseId { get; set; }
    public FormResponse FormResponse { get; set; }

    [Required]
    public long FormQuestionId { get; set; }
    public FormQuestion FormQuestion { get; set; }

    public string Response { get; set; }
}
