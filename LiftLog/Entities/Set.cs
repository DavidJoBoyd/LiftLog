namespace LiftLog.Entities;

public class Set
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
    public Exercise Exercise { get; set; }
    public int? WorkoutProgramId { get; set; }
    public WorkoutProgram? WorkoutProgram { get; set; }
}
