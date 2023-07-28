namespace Application.Models;

public class WorkoutProgramModel
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; } 

    public ICollection<SetModel> Sets { get; set; }
}
