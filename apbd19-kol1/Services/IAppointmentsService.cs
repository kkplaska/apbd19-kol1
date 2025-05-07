using apbd19_kol1.Models.Dtos;

namespace apbd19_kol1.Services;

public interface IAppointmentsService
{
    Task<VisitDto> GetPatientVisit(int id);
    Task<AppointmentDto> AddAppointment(AppointmentDto appointment);
}