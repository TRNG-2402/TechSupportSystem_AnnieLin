using Microsoft.EntityFrameworkCore;
using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Data;

public class SupportTicketRepo : ISupportTicketRepo
{
    private readonly SupportSystemDbContext _context;

    public SupportTicketRepo(SupportSystemDbContext context)
    {
        _context = context;
    }

    public async Task<SupportTicket> CreateTicketAsync(SupportTicket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<List<SupportTicket>> DisplayAllTicketsAsync()
    {
        return await _context.Tickets.Include(t => t.Technicians).Include(n => n.Notes).ToListAsync();
    }

    public async Task<SupportTicket?> GetTicketByIDAsync(int id)
    {
        return await _context.Tickets.FindAsync(id);

    }

    public async Task<SupportTicket> UpdateTicketAsync(SupportTicket ticket)
    {
        _context.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<SupportTicket> DeleteTicketAsync(SupportTicket ticket)
    {
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }
}