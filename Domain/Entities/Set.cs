using Domain.Enums;

namespace Domain.Entities;

public class Set
{
    public int Id { get; set; }
    public int Reps { get; set; } = 0;
    public int Weight { get; set; } = 0;
    public Exercise Exercise { get; set; }
    public int? WorkoutProgramId { get; set; }
    public WorkoutProgram? WorkoutProgram { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
