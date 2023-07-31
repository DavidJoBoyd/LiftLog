using Application.Mappers;
using Application.Models;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Commands;

public sealed record GetProgram(int Id) : IRequest<WorkoutProgramModel>;

public class GetProgramHandler : IRequestHandler<GetProgram, WorkoutProgramModel>
{
    private readonly LiftLogContext _context;

    public GetProgramHandler(LiftLogContext context)
    {
        _context = context;
    }
    
    public async Task<WorkoutProgramModel> Handle(GetProgram request, CancellationToken cancellationToken)
    {
        var program = await _context.WorkoutPrograms
            .Include(x => x.Sets)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
 
        return program?.ToModel() ?? new WorkoutProgramModel();
    }
}
