using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Resources;

public class ContractResource
{
    public int Id { get; set; }
    public PublicationResource Publication { get; set; }
    public ExpertResource Expert { get; set; }
    public string Price { get; set; }
    public string State { get; set; }
}