using LiftLog.Context;
using LiftLog.Entities;
using Microsoft.AspNetCore.Components;

namespace LiftLog.Pages;

public partial class AddProgram : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private LiftLogContext Context { get; set; }


    private WorkoutProgram _program = new();
    
    private Task AddSet()
    {
        _program.Sets.Add(new Set());
        return Task.CompletedTask;
    }

    private async Task Save()
    {
        Context.WorkoutPrograms.Add(_program);
        await Context.SaveChangesAsync();
        NavigationManager.NavigateTo("/programspage");
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
