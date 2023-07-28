using Application.Commands;
using Application.Models;
using LiftLog.Misc;
using MediatR;
using Microsoft.AspNetCore.Components;


namespace LiftLog.Pages;

public partial class ProgramsPage : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    
    [Inject] private IMediator Mediator { get; set; } = default!;
    [Inject] AppState AppState { get; set; } = default!;

    private List<WorkoutProgramModel> _programs = new();
    
    protected override async Task OnInitializedAsync()
    {
        var result = await Mediator.Send(new GetAllPrograms());
        _programs = result;
    }
    private void LoadData()
    {
        NavigationManager.NavigateTo("/addprogramspage");
    }

    private async Task Delete(WorkoutProgramModel program)
    {
        // Context.WorkoutPrograms.Remove(program);
        // await Context.SaveChangesAsync();
        // _programs = await Context.WorkoutPrograms.ToListAsync();
        // StateHasChanged();
    }

    private Task Edit(WorkoutProgramModel program)
    {
        // AppState.SelectedWorkoutId = program.Id;
        // NavigationManager.NavigateTo("/editprogramspage");
        return Task.CompletedTask;
    }
}
