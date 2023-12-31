using System.ComponentModel.DataAnnotations;

namespace FastService.API.FastService.Resources;

public class SavePublicationResource
{
    [Required]
    [MaxLength(120)]
    public string Address { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(300)]
    public string Description { get; set; }


    [Required]
    public bool IsPublished { get; set; }

    [Required]
    public int ClientId { get; set; }

    [Required]
    [MaxLength(120)]
    public string Image { get; set; }
}