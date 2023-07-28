using Application.Mappers;
using Application.Models;
using Domain.Entities;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Commands;

public sealed record CreateProgram(WorkoutProgramModel Program) : IRequest;

public class CreateProgramHandler : IRequestHandler<CreateProgram>
{
    private readonly LiftLogContext _context;

    public CreateProgramHandler(LiftLogContext context)
    {
        _context = context;
    }
    
    public async Task Handle(CreateProgram request, CancellationToken cancellationToken)
    {
        var newProgram = new WorkoutProgram();
        newProgram.Update(request.Program);
        _context.WorkoutPrograms.Add(newProgram);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
