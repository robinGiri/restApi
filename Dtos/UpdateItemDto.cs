using System.ComponentModel.DataAnnotations;

namespace Catalog.Dto;

public class UpdateItemDto
{
    [Required]
    public string Name { get; init; }
    [Range(1, 1000)]
    [Required]
    public double Price { get; init; }
}