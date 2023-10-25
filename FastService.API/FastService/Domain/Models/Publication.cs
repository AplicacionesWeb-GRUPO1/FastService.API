namespace LearningCenter.API.Learning.Domain.Models;

public class Publication
{
    // id name address title description isPublished
    public int Id { get; set; }
    public string Address { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublished { get; set; }
    
    // Relationships
    public int ClientId { get; set; }
    public Client Client { get; set; }
    
}
