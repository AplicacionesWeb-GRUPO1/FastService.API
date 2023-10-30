namespace FastService.API.FastService.Domain.Models;

public class Gallery
{
    // id name address title description isPublished image
    public int Id { get; set; }
    public string ImgUrl { get; set; }
    public int ExpertId { get; set; }
    // Relationships
    public Expert Expert { get; set; }
}
