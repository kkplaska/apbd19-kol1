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
    public async Task<IActionResult> GetAppointments()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddClient(AppointmentDto appointment)
    {
        return Created();
    }
    
}