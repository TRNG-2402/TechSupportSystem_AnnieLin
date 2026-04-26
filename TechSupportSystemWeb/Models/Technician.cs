using System.Text.Json.Serialization;

namespace TechSupportSystemWeb.Models;

public class Technician
{
    public int ID { get; set; }
    public string Name { get; set; } = "";

    [JsonIgnore]
    public List<SupportTicket> Tickets { get; set; } = new List<SupportTicket>();
}