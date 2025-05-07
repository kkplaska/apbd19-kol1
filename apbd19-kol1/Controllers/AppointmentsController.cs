using apbd19_kol1.Models.Dtos;
using apbd19_kol1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbd19_kol1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentsService _appointmentsService;

    public AppointmentsController(IAppointmentsService appointmentsService)
    {
        _appointmentsService = appointmentsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientVisit(int id)
    {
        var patientVisit = await _appointmentsService.GetPatientVisit(id);
        
        return Ok(patientVisit);
    }

    [HttpPost]
    public async Task<IActionResult> AddClient(AppointmentDto appointment)
    {
        await _appointmentsService.AddAppointment(appointment);
        return Created();
    }
    
}