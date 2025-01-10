using CVB.BL.Domain.AppointmentPck;

namespace CVB.DAL.Repository.AppointmentPck;

public interface IAppointmentRepository
{
    Appointment GetAppointmentById(Guid id);
    void CreateAppointment(Appointment appointment);
    void UpdateAppointment(Appointment appointment);
    void DeleteAppointmentById(Guid id);
    IEnumerable<Appointment> GetAllAppointments();
}