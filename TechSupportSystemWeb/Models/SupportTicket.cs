namespace TechSupportSystemWeb.Models;

public class SupportTicket
{
    public int ID { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }

    public string Status { get; set; } = "Open";
    public string Priority { get; set; } = "Low";

    public List<Technician> Technicians { get; set; } = new List<Technician>();
    public List<SupportNote> Notes { get; set; } = new List<SupportNote>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
