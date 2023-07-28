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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Set>()
            .HasOne(s => s.WorkoutProgram)
            .WithMany(w => w.Sets)
            .HasForeignKey(s => s.WorkoutProgramId);
        
        builder.Entity<WorkoutProgram>()
            .HasMany(w => w.Sets)
            .WithOne(s => s.WorkoutProgram)
            .HasForeignKey(s => s.WorkoutProgramId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=LiftLog;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
