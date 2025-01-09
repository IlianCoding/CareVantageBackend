namespace CVB.BL.Domain.Appointment;

public class AppointmentDetails
{
    public Guid Id { get; set; }
    public Guid AppointmentId { get; set; }
    public required string Information { get; set; }
    public string? Notes { get; set; }
    
    public virtual required Appointment Appointment { get; set; }
}