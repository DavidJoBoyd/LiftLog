using LiftLog.Context;
using LiftLog.Entities;
using LiftLog.Misc;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;


namespace LiftLog.Pages;

public partial class ProgramsPage : ComponentBase
{
    [Inject] private LiftLogContext Context { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] AppState AppState { get; set; } = default!;

    private List<WorkoutProgram> _programs = new();
    
    protected override async Task OnInitializedAsync()
    {
        _programs = await Context.WorkoutPrograms.ToListAsync();
    }
    private void LoadData()
    {
        NavigationManager.NavigateTo("/addprogramspage");
    }

    private async Task Delete(WorkoutProgram program)
    {
        Context.WorkoutPrograms.Remove(program);
        await Context.SaveChangesAsync();
        _programs = await Context.WorkoutPrograms.ToListAsync();
        StateHasChanged();
    }

    private Task Edit(WorkoutProgram program)
    {
        AppState.SelectedWorkoutId = program.Id;
        NavigationManager.NavigateTo("/editprogramspage");
        return Task.CompletedTask;
    }
}
