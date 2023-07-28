using LiftLog.Entities;
using LiftLog.Models;

namespace LiftLog.Mappers;

public static class WorkoutProgramMapper
{
    public static WorkoutProgramModel ToModel(this WorkoutProgram workoutProgram)
    {
        return new WorkoutProgramModel
        {
            Id = workoutProgram.Id,
            Name = workoutProgram.Name,
            Description = workoutProgram.Description,
            Sets = workoutProgram.Sets.Select(set => set.ToModel()).ToList()
        };
    }
    
    public static WorkoutProgram Update(this WorkoutProgram entity, WorkoutProgramModel model)
    {
        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.Sets = model.Sets.Select(set => set.ToEntity()).ToList();

        return entity;
    }

}
