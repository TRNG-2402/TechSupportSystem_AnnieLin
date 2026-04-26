using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Data;

public interface ISupportTicketRepo
{
    Task<SupportTicket> CreateTicketAsync(SupportTicket ticket);
    Task<List<SupportTicket>> DisplayAllTicketsAsync();
    Task<SupportTicket> GetTicketByIDAsync(int id);
    Task<SupportTicket> UpdateTicketAsync(SupportTicket ticket);
    Task<SupportTicket> DeleteTicketAsync(SupportTicket ticket);

}