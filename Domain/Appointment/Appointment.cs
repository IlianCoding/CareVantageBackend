namespace CVB.BL.Domain.Appointment;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public AppointmentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public virtual required AppointmentDetails Details { get; set; }
}