using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Services;
public interface ITechnicianService
{
    Task<List<Technician>> GetAllTechniciansAsync();
    Task<Technician> CreateTechnicianAsync(Technician tech);
    Task<Technician> DeleteTechnicianAsync(int id);
}