namespace TechSupportSystemWeb.Models;

public class SupportNote
{
    public int ID { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}