using Domain.Enums;

namespace Domain.Entities;

public sealed class WorkoutProgram
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<Set> Sets = new List<Set>();

}
