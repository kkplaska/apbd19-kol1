using apbd19_kol1.Models.Dtos;

namespace apbd19_kol1.Services;

public class AppointmentsService : IAppointmentsService
{
    private readonly string? _connectionString;
    public AppointmentsService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<VisitDto> GetPatientVisit(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<AppointmentDto> AddAppointment(AppointmentDto appointment)
    {
        throw new NotImplementedException();
    }
}