using Application.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace LiftLog.Pages;

public partial class AddProgram : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IMediator Mediator { get; set; } = default!;



    private WorkoutProgramModel _program = new();
    
    private Task AddSet()
    {
        _program.Sets.Add(new SetModel());
        return Task.CompletedTask;
    }

    private async Task Save()
    {
        await Mediator.Send(new CreateProgram(_program));
        NavigationManager.NavigateTo("/programspage");

    }

    private void Delete(SetModel set)
    {
        _program.Sets.Remove(set);
    }

    private Task Back()
    {
        NavigationManager.NavigateTo("/programspage");
        return Task.CompletedTask;
    }
}
