using System.ComponentModel.DataAnnotations;

namespace CVB.API.Models.ServicePck;

public class AddServiceDto
{
    [Required]
    public bool IsActive { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required, MaxLength(500)]
    public string Description { get; set; }
    [Range(0.01, 50.0)]
    public decimal Price { get; set; }
    [Required]
    public string BillingType { get; set; }
}