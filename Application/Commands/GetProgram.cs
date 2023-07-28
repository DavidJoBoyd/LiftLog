using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public class GetProgram
{
    private readonly LiftLogContext _context;

    public GetProgram(LiftLogContext context)
    {
        _context = context;
    }

    public async Task<WorkoutProgram> Handle(int programId)
    {
        var program = await _context.WorkoutPrograms.FirstOrDefaultAsync(p => p.Id == programId);

        if (program == null)
        {
            throw new Exception($"Program with id {programId} not found.");
        }

        return program;
    }
}
