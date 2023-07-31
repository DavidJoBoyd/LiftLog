using Application.Commands;
using Application.Models;
using LiftLog.Misc;
using MediatR;
using Microsoft.AspNetCore.Components;


namespace LiftLog.Pages;

public partial class ProgramsPage : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
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

    private async Task Delete(int id)
    {
        await Mediator.Send(new DeleteProgram(id));
        _programs =  await Mediator.Send(new GetAllPrograms());
        StateHasChanged();
    }

    private Task Edit(int id)
    {
        AppState.SelectedWorkoutId = id;
        NavigationManager.NavigateTo("/editprogramspage");
        return Task.CompletedTask;
    }
}
