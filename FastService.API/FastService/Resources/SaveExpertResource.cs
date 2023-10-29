using System.ComponentModel.DataAnnotations;

namespace FastService.API.FastService.Resources;

public class SaveExpertResource
{
    [Required]
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public decimal Money { get; set; }
    //Rating
    public decimal Rating { get; set; }
    public string Avatar { get; set; }
    public string Role { get; set; }
}