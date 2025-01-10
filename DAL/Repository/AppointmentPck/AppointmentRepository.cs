using CVB.BL.Domain.AppointmentPck;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.AppointmentPck;

public class AppointmentRepository(CareVantageDbContext context) : IAppointmentRepository
{
    public Appointment GetAppointmentById(Guid id)
    {
        return context.Appointments
            .Include(d => d.Details)
            .SingleOrDefault(x => x.Id == id);
    }

    public void CreateAppointment(Appointment appointment)
    {
        context.Appointments.Add(appointment);
    }

    public void UpdateAppointment(Appointment appointment)
    {
        context.Appointments.Update(appointment);
    }
    
    public void DeleteAppointmentById(Guid id)
    {
        Appointment appointment = GetAppointmentById(id);
        context.Appointments.Remove(appointment);
    }

    public IEnumerable<Appointment> GetAllAppointments()
    {
        return context.Appointments
            .Include(d => d.Details)
            .ToList();
    }
}