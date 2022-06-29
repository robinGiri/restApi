using System.ComponentModel.DataAnnotations;

namespace Catalog.Dto;

public record CreateItemDto
{
    [Required]
    public string Name { get; init; }
    [Range(1, 1000)]
    [Required]
    public double Price { get; init; }
}
