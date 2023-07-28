using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public class DeleteProgram
{
    private readonly LiftLogContext _context;

    public DeleteProgram(LiftLogContext context)
    {
        _context = context;
    }

    public async Task Handle(int programId)
    {
        var program = await _context.WorkoutPrograms.FirstOrDefaultAsync(p => p.Id == programId);

        if (program == null)
        {
            throw new Exception($"Program with id {programId} not found.");
        }

        _context.WorkoutPrograms.Remove(program);
        await _context.SaveChangesAsync();
    }
}