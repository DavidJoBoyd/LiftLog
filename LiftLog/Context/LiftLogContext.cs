using LiftLog.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiftLog.Context;

public class LiftLogContext : DbContext
{
    public DbSet<WorkoutProgram> WorkoutPrograms { get; set; } = default!;
    
    public DbSet<Set> Sets { get; set; } = default!;
    
    public LiftLogContext(DbContextOptions<LiftLogContext> options)
        : base(options)
    {            
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=LiftLog;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
