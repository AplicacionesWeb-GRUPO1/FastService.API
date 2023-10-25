namespace LearningCenter.API.Learning.Domain.Models;

public class Client
{
    // id name lastname phone Birthdaydate money
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public decimal Money { get; set; }
    // Relationships
    
    public IList<Publication> Publications { get; set; } = new List<Publication>();
}
