namespace FastService.API.FastService.Domain.Models;

public class Contract
{
    // id name address title description isPublished image
    public int Id { get; set; }
    public int PublicationId { get; set; }
    public int ExpertId { get; set; }
    public int Price { get; set; }
    public string State { get; set; }

    // Relationships
    public Publication Publication { get; set; }
    public Expert Expert { get; set; }

}
