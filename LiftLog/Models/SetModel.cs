using LiftLog.Entities;

namespace LiftLog.Models;

public class SetModel
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
    public Exercise Exercise { get; set; }
    public DateTime CreatedAt { get; set; }
}
