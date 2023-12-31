namespace FastService.API.FastService.Domain.Models;

public class Publication
{
    // id name address title description isPublished image
    public int Id { get; set; }
    public string Address { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublished { get; set; }
    public string Image { get; set; }
    // Relationships
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public IList<Contract> Contracts { get; set; } = new List<Contract>();
}
