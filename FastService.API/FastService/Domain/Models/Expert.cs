namespace FastService.API.FastService.Domain.Models;

public class Expert
{
    // id name lastname phone Birthdaydate money rating avatar role
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public decimal Money { get; set; }
    public decimal Rating { get; set; }
    public string Avatar { get; set; }
    public string Role { get; set; }
    // Relationships
    public List<Contract> Contracts { get; set; } = new List<Contract>();
    public List<Gallery> Galleries { get; set; } = new List<Gallery>();

}
