using Application.Mappers;
using Application.Models;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Commands;

public sealed record GetAllPrograms : IRequest<List<WorkoutProgramModel>>;

public class GetAllProgramsHandler : IRequestHandler<GetAllPrograms, List<WorkoutProgramModel>>
{
    private readonly LiftLogContext _context;

    public GetAllProgramsHandler(LiftLogContext context)
    {
        _context = context;
    }
    public async Task<List<WorkoutProgramModel>> Handle(GetAllPrograms request, CancellationToken cancellationToken)
    {
        var programs = await _context.WorkoutPrograms
            .Include(x => x.Sets)
            .ToListAsync(cancellationToken: cancellationToken);
        return programs.Select(x => x.ToModel()).ToList();
    }
}
