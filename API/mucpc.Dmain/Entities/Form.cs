using System.ComponentModel.DataAnnotations;


namespace mucpc.Domain.Entities;

public class Form
{
    [Key]
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool RegistrationForm { get; set; }
    public bool EvaluationForm { get; set; }
    public long WorkShopId { get; set; }
    public WorkShop? WorkShop { get; set; }
    public ICollection<FormQuestion>? FormQuestions { get; set; }
    public ICollection<FormResponse>? FormResponses { get; set; }
}
