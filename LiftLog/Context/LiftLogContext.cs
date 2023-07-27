using LiftLog.Data;
using Microsoft.EntityFrameworkCore;

namespace LiftLog.Context;

public class LiftLogContext : DbContext
{
    public DbSet<WorkoutProgram> WorkoutPrograms { get; set; } = default!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=LiftLog;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
