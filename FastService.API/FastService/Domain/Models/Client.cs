namespace FastService.API.FastService.Domain.Models;

public class Client
{
    // id name lastname phone Birthdaydate money avatar role
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public decimal Money { get; set; }
    public string Avatar { get; set; }
    public string Role { get; set; }

    // Relationships
    public IList<Publication> Publications { get; set; } = new List<Publication>();
    public IList<Contract> Contracts { get; set; } = new List<Contract>();

}
