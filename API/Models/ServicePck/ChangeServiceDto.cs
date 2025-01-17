using System.ComponentModel.DataAnnotations;

namespace CVB.API.Models.ServicePck;

public class ChangeServiceDto : AddServiceDto
{
    [Required]
    public Guid Id { get; set; }
}