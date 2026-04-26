using Microsoft.EntityFrameworkCore;
using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Data;

public class TechnicianRepo : ITechnicianRepo
{
    private readonly SupportSystemDbContext _context;

    public TechnicianRepo(SupportSystemDbContext context)
    {
        _context = context;
    }
    public async Task<List<Technician>> GetAllTechniciansAsync()
    {
        return await _context.Technicians.Include(t => t.Tickets).ToListAsync();
    }

    public async Task<Technician> CreateTechnicianAsync(Technician tech)
    {
        _context.Technicians.Add(tech);
        await _context.SaveChangesAsync();
        return tech;
    }

    public async Task<Technician?> GetTechnicianByIDAsync(int id)
    {
        return await _context.Technicians.FindAsync(id);
    }

    public async Task<Technician> DeleteTechnicianAsync(Technician tech)
    {
        _context.Technicians.Remove(tech);
        await _context.SaveChangesAsync();
        return tech;
    }
}