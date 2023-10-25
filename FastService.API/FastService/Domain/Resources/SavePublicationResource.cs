using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Learning.Resources;

public class SavePublicationResource
{
    [Required]
    [MaxLength(120)]
    public string Address { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(120)]
    public string Description { get; set; }


    [Required]
    public bool IsPublished { get; set; }

    [Required]
    public int ClientId { get; set; }
}