using Microsoft.AspNetCore.Mvc;
using TechSupportSystemWeb.Models;
using TechSupportSystemWeb.Services;

namespace TechSupportSystemWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnicianController : ControllerBase
{
    private readonly ITechnicianService _service;

    public TechnicianController(ITechnicianService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Technician>>> GetAllTechnicians()
    {
        try
        {
            return await _service.GetAllTechniciansAsync();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Technician>> CreateTechnician(Technician tech)
    {
        try
        {
            return await _service.CreateTechnicianAsync(tech);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Technician>> DeleteTechnician(int id)
    {
        try
        {
            return await _service.DeleteTechnicianAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}