using Microsoft.EntityFrameworkCore;
using TechSupportSystemWeb.Models;

namespace TechSupportSystemWeb.Data;

public class SupportSystemDbContext : DbContext
{
    public SupportSystemDbContext(DbContextOptions<SupportSystemDbContext> options) : base(options) { }
    public DbSet<SupportTicket> Tickets { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<SupportNote> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupportTicket>().HasMany(t => t.Technicians).WithMany(t => t.Tickets);
        modelBuilder.Entity<SupportTicket>().HasMany(n => n.Notes).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}