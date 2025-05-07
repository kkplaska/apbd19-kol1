namespace apbd19_kol1.Models.Dtos;

public class AppointmentDto
{
    public int appointmentId { get; set; }
    public int patientId { get; set; }
    public string pwz { get; set; } = string.Empty;
    public List<ServiceDto> services { get; set; } = null!;
}