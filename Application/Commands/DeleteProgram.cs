using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Commands;

public sealed record DeleteProgram(int Id) : IRequest;

public class DeleteProgramHandler : IRequestHandler<DeleteProgram>
{
    private readonly LiftLogContext _context;

    public DeleteProgramHandler(LiftLogContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteProgram request, CancellationToken cancellationToken)
    {
        var program = _context.WorkoutPrograms
            .Include(x => x.Sets)
            .FirstOrDefault(x => x.Id == request.Id);
        if (program != null) _context.WorkoutPrograms.Remove(program);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
