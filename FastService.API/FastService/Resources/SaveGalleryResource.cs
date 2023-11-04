using System.ComponentModel.DataAnnotations;

namespace FastService.API.FastService.Resources;

public class SaveGalleryResource
{
    [Required]
    [MaxLength(200)]
    public string ImgUrl { get; set; }
    [Required]
    public int ExpertId { get; set; }

}