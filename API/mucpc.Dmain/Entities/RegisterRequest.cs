using System.ComponentModel.DataAnnotations;

namespace mucpc.Domain.Entities;

public class RegisterRequest
{
    [Key]
    public long Id { get; set; }
    public DateTime RequestDateTime { get; set; } = DateTime.Now;
    public long? StudentId { get; set; }
    public Student? Student { get; set; }
    public long FormResponseId { get; set; }
    public FormResponse FormResponse { get; set; }
    public bool isAccepted { get; set; } = false;
    public string? Status { get; set; }
    public long WorkShopId { get; set; }
    public WorkShop WorkShop { get; set; }


}
