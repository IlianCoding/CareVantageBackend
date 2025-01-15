using System.ComponentModel.DataAnnotations;

namespace CVB.BL.Domain.ServicePck;

public class ServiceFeature
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name must contain at most 100 characters.")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description must contain at most 500 characters.")]
    public required string Description { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly? UpdatedAt { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Purchase count must be a positive number.")]
    public int PurchaseCount { get; set; }
    
    [Range(0, 5, ErrorMessage = "Rating must be a number between 0 and 5.")]
    public double Rating { get; set; }
    
    public virtual Service? Service { get; set; }
}