namespace mucpc.Application.Forms.Dtos;

public class FormDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool RegistrationForm { get; set; }
    public bool EvaluationForm { get; set; }
    public long WorkShopId { get; set; }

}
