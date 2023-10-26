using System.ComponentModel.DataAnnotations;

namespace FastService.API.FastService.Resources;

public class SaveContractResource
{
    [Required]
    public int PublicationId { get; set; }
    
    [Required]
    public int ExpertId { get; set; }
    
    [Required]
    public decimal Price { get; set; }

    [Required] //state
    public string State { get; set; }
}