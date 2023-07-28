using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public class UpdateProgram
{
    private readonly LiftLogContext _context;

    public UpdateProgram(LiftLogContext context)
    {
        _context = context;
    }

    public async Task Handle(WorkoutProgram updatedProgram)
    {
        var program = await _context.WorkoutPrograms.FirstOrDefaultAsync(p => p.Id == updatedProgram.Id);

        if (program == null)
        {
            throw new Exception($"Program with id {updatedProgram.Id} not found.");
        }

        program.Name = updatedProgram.Name;
        program.Description = updatedProgram.Description;

        _context.WorkoutPrograms.Update(program);
        await _context.SaveChangesAsync();
    }
}
