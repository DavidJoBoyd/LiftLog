using Application.Models;
using Domain.Entities;

namespace Application.Mappers;

public static class SetMapper
{
    public static SetModel ToModel(this Set set)
    {
        return new SetModel
        {
            Id = set.Id,
            Reps = set.Reps,
            Weight = set.Weight,
            Exercise = set.Exercise,
            CreatedAt = set.CreatedAt
        };
    }
    public static Set ToEntity(this SetModel model)
    {
        return new Set
        {
            Id = model.Id,
            Reps = model.Reps,
            Weight = model.Weight,
            Exercise = model.Exercise,
            CreatedAt = model.CreatedAt,
        };
    }
}
