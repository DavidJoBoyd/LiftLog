namespace LiftLog.Data;

public class WorkoutProgram
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public List<Set> Sets { get; set; } = new List<Set>();
}
