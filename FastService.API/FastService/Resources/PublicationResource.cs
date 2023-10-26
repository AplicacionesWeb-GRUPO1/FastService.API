using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Resources;

public class PublicationResource
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublished { get; set; }
    public ClientResource Client { get; set; }
}