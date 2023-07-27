using LiftLog.Context;
using LiftLog.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace LiftLog.Pages;

public partial class ProgramsPage : ComponentBase
{
    [Inject] private LiftLogContext Context { get; set; }
    
    private List<WorkoutProgram>? _programs;

    private bool _showEdit;

    protected override async Task OnInitializedAsync()
    {
        _programs = await Context.WorkoutPrograms.ToListAsync();
        
    }
    private async Task LoadData()
    {
        var x = new WorkoutProgram()
        {
            Name = "Arms",
            Sets = new List<Set>()
            {
                new Set
                {
                    Reps = 10,
                    Weight = 225,
                    Exercise = Exercise.Squat
                },
            }
        };
        Context.WorkoutPrograms.Add(x);
        await Context.SaveChangesAsync(default);
        _showEdit = !_showEdit;
        StateHasChanged();
    }
}
