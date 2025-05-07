using apbd19_kol1.Models.Dtos;
using Microsoft.Data.SqlClient;

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
        var appointmentId = id;
        var appointmentServices = new List<AppointmentServiceDto>();
        
        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand();
        command.Connection = connection;
        await connection.OpenAsync();
        var date = new DateTime();
        var patientDto = new PatientDto();
        var doctorDto = new DoctorDto();
        

        command.CommandText = "SELECT a.date, p.first_name, p.last_name, p.date_of_birth, d.doctor_id, d.PWZ FROM appointment a INNER JOIN patient p ON p.patient_id = a.patient_id INNER JOIN doctor d ON d.doctor_id = a.doctor_id WHERE appoitment_id = @id";
        command.Parameters.AddWithValue("@id", appointmentId);

        using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                date = reader.GetDateTime(0);

                patientDto.dateOfBirth = reader.GetDateTime(3);
                patientDto.firstName = reader.GetString(1);
                patientDto.lastName = reader.GetString(2);
                
                doctorDto.doctorId = reader.GetInt32(4);
                doctorDto.pwz = reader.GetString(5);
            }
        };
        
        command.Parameters.Clear();
            
        command.CommandText = "SELECT s.name, s.base_fee FROM appointment_service a INNER JOIN Service s ON a.service_id = s.service_id WHERE a.appoitment_id = @id";
        command.Parameters.AddWithValue("@id", appointmentId);

        using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                appointmentServices.Add(new AppointmentServiceDto()
                {
                    name = reader.GetString(0),
                    serviceFee = reader.GetDecimal(1)
                });
                
            }
        }
        
        var visit = new VisitDto()
        {
            patient = patientDto,
            doctor = doctorDto,
            appointmentServices = appointmentServices,
            date = date
        };
        
        return visit;
    }

    public async Task<AppointmentDto> AddAppointment(AppointmentDto appointment)
    {
        throw new NotImplementedException();
    }
}