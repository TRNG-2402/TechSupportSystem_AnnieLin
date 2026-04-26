using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Data;

public interface ITechnicianRepo
{
    Task<List<Technician>> GetAllTechniciansAsync();
    Task<Technician> CreateTechnicianAsync(Technician tech);
    Task<Technician> GetTechnicianByIDAsync(int id);
    Task<Technician> DeleteTechnicianAsync(Technician tech);
}