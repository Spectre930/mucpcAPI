
namespace mucpc.Domain.Entities;

public class FormResponse
{
    public long Id { get; set; }
    public long FormId { get; set; }
    public Form Form { get; set; }
    public long? StudentId { get; set; }
    public Student? Student { get; set; }
    public ICollection<QuestionResponse> QuestionsResponses { get; set; }

}
