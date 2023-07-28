using Domain.Entities;
using LiftLog.Misc;
using Microsoft.AspNetCore.Components;

namespace LiftLog.Pages;

public partial class EditProgram : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] AppState AppState { get; set; } = default!;


    private WorkoutProgram _program = new();
    
    protected override Task OnInitializedAsync()
    {
        // _program = Context.WorkoutPrograms
        //     .Include(x=>x.Sets)
        //     .FirstOrDefault(x => x.Id == AppState.SelectedWorkoutId) ?? new WorkoutProgram();
        return Task.CompletedTask;
    }

    private Task AddSet()
    {
        _program.Sets.Add(new Set());
        return Task.CompletedTask;
    }

    private async Task Save()
    {
        // Context.WorkoutPrograms.Update(_program);
        // await Context.SaveChangesAsync();
        // NavigationManager.NavigateTo("/programspage");
    }
    
    private void Delete(Set set)
    {
        _program.Sets.Remove(set);
    }
    private Task Back()
    {
        NavigationManager.NavigateTo("/programspage");
        return Task.CompletedTask;
    }
}
