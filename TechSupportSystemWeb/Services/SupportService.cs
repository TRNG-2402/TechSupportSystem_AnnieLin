using TechSupportSystemWeb.Models;
using TechSupportSystemWeb.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Microsoft.AspNetCore.Http.HttpResults;
using TechSupportSystemWeb.DTOs;
namespace TechSupportSystemWeb.Services;

public class SupportService : ISupportService
{
    private readonly ISupportTicketRepo _repo;

    public SupportService(ISupportTicketRepo repo)
    {
        _repo = repo;
    }
    public async Task<SupportTicket> CreateTicketAsync(SupportTicketDTO ticket)
    {
        SupportTicket newTicket = new SupportTicket();
        newTicket.Title = ticket.Title;
        newTicket.Description = ticket.Description;

        return await _repo.CreateTicketAsync(newTicket);
    }

    public async Task<List<SupportTicket>> DisplayAllTicketsAsync()
    {
        List<SupportTicket> result = await _repo.DisplayAllTicketsAsync();

        if (result is null)
        {
            throw new NullReferenceException("There are no tickets to display!");
        }
        return result;
    }

    public async Task<SupportTicket> GetTicketByIDAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");
        }
        SupportTicket ticket = await _repo.GetTicketByIDAsync(id);
        if (ticket == null)
        {
            throw new Exception("Ticket not found!");
        }
        else
        {
            return ticket;
        }
    }

    public async Task<SupportTicket> UpdateTicketAsync(int id, SupportTicket ticket)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");
        }
        SupportTicket find = await _repo.GetTicketByIDAsync(id);
        if (find == null)
        {
            throw new Exception("Ticket not found!");
        }
        else
        {
            find.Title = ticket.Title;
            find.Description = ticket.Description;
            find.Status = ticket.Status;
            find.Priority = ticket.Priority;
            find.Notes = ticket.Notes;
            find.Technicians = ticket.Technicians;
            return await _repo.UpdateTicketAsync(find);
        }
    }

    public async Task<SupportTicket> DeleteTicketAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");
        }

        SupportTicket ticket = await _repo.GetTicketByIDAsync(id);

        if (ticket is null)
        {
            throw new KeyNotFoundException("Ticket not found!");
        }
        return await _repo.DeleteTicketAsync(ticket);
    }
}