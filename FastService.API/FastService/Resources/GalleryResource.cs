using FastService.API.FastService.Domain.Models;

namespace FastService.API.FastService.Resources;

public class GalleryResource
{
    public int Id { get; set; }
    public string ImgUrl { get; set; }
    public ExpertResource Expert { get; set; }
}