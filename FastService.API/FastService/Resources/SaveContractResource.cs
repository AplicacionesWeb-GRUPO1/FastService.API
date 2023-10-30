using System.ComponentModel.DataAnnotations;

namespace FastService.API.FastService.Resources;

public class SaveContractResource
{

    public int PublicationId { get; set; }
    public int ExpertId { get; set; }
    public decimal Price { get; set; }
    public string State { get; set; }
    public string Date { get; set; }
}