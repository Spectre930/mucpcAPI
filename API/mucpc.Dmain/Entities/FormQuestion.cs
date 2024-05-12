using System.ComponentModel.DataAnnotations;

namespace mucpc.Domain.Entities;

public class FormQuestion
{
    [Key]
    public long Id { get; set; }
    public string Question { get; set; }
    public string Type { get; set; }
    public string? Options { get; set; }
    public long FormId { get; set; }
    public Form Form { get; set; }

    public ICollection<QuestionResponse> QuestionResponses { get; set; }
}
