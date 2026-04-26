using TechSupportSystemWeb.Data;
using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Services;

public class TechnicianService : ITechnicianService
{
    private readonly ITechnicianRepo _repo;
    public TechnicianService(ITechnicianRepo repo)
    {
        _repo = repo;
    }
    public async Task<List<Technician>> GetAllTechniciansAsync()
    {
        List<Technician> result = await _repo.GetAllTechniciansAsync();
        if (result is null)
        {
            throw new NullReferenceException("There are no technicians!");
        }
        return result;
    }

    public async Task<Technician> CreateTechnicianAsync(Technician tech)
    {
        Technician newTech = new Technician();
        newTech.ID = tech.ID;
        newTech.Name = tech.Name;
        newTech.Tickets = tech.Tickets;
        return await _repo.CreateTechnicianAsync(newTech);
    }

    public async Task<Technician> DeleteTechnicianAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");
        }

        Technician tech = await _repo.GetTechnicianByIDAsync(id);

        if (tech is null)
        {
            throw new KeyNotFoundException("Technician not found!");
        }
        return await _repo.DeleteTechnicianAsync(tech);
    }
}