using Microsoft.AspNetCore.Mvc;
using TechSupportSystemWeb.Services;
using TechSupportSystemWeb.Models;
using TechSupportSystemWeb.DTOs;

namespace TechSupportSystemWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupportTicketController : ControllerBase
{
    private readonly ISupportService _service;
    public SupportTicketController(ISupportService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupportTicket>>> GetAllTickets()
    {
        try
        {
            return await _service.DisplayAllTicketsAsync();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SupportTicket>> GetTicketByID(int id)
    {
        try
        {
            return await _service.GetTicketByIDAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<SupportTicket>> CreateTicket(SupportTicketDTO ticket)
    {
        try
        {
            return await _service.CreateTicketAsync(ticket);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SupportTicket>> UpdateTicket(int id, SupportTicket ticket)
    {
        try
        {
            return await _service.UpdateTicketAsync(id, ticket);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SupportTicket>> DeleteTicket(int id)
    {
        try
        {
            return await _service.DeleteTicketAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}