using Application.Mappers;
using Application.Models;
using Domain.Entities;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Commands;

public sealed record UpdateProgram(WorkoutProgramModel Program) : IRequest;

public class UpdateProgramHandler : IRequestHandler<UpdateProgram>
{
    private readonly LiftLogContext _context;

    public UpdateProgramHandler(LiftLogContext context)
    {
        _context = context;
    }
    
    public async Task Handle(UpdateProgram request, CancellationToken cancellationToken)
    {
        var sets = request.Program.Sets.Where(x => x.Id == 0).ToList();
        
        foreach (var set in sets)
        {
            var newSet = set.ToEntity();
            _context.Sets.Add(newSet);
        }
        await _context.SaveChangesAsync(cancellationToken);
        
        var program = await _context.WorkoutPrograms
            .Include(x => x.Sets)
            .FirstOrDefaultAsync(x => x.Id == request.Program.Id, cancellationToken: cancellationToken);
        
        if (program != null) program.Update(request.Program);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
