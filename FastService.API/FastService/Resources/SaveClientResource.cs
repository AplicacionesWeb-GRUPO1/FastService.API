using System.ComponentModel.DataAnnotations;

namespace FastService.API.FastService.Resources;

public class SaveClientResource
{
    [Required]
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public decimal Money { get; set; }

}