using System.Xml.Serialization;
using TechSupportSystemWeb.DTOs;
using TechSupportSystemWeb.Models;
namespace TechSupportSystemWeb.Services;

public interface ISupportService
{
    Task<SupportTicket> CreateTicketAsync(SupportTicketDTO ticket);
    Task<List<SupportTicket>> DisplayAllTicketsAsync();
    Task<SupportTicket?> GetTicketByIDAsync(int id);
    Task<SupportTicket> UpdateTicketAsync(int id, SupportTicket ticket);
    Task<SupportTicket> DeleteTicketAsync(int id);

}