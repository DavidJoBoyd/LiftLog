using Application.Commands;
using Application.Models;
using Domain.Entities;
using LiftLog.Misc;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace LiftLog.Pages;

public partial class EditProgram : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; } =default!;
    [Inject] private IMediator Mediator { get; set; } = default!;
    [Inject] AppState AppState { get; set; } = default!;

    private WorkoutProgramModel _program = new();
    
    protected override async Task OnInitializedAsync()
    {
        _program = await Mediator.Send(new GetProgram(AppState.SelectedWorkoutId));
    }

    private Task AddSet()
    {
        _program.Sets.Add(new SetModel());
        return Task.CompletedTask;
    }

    private async Task Save()
    {
        await Mediator.Send(new UpdateProgram(_program));
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
