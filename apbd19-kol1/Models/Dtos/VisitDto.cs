namespace apbd19_kol1.Models.Dtos;

public class VisitDto
{
    public DateTime date { get; set; }
    public PatientDto patient { get; set; }
    public DoctorDto doctor { get; set; }
    public List<ServiceDto> appointmentServices { get; set; } = null!;
}
