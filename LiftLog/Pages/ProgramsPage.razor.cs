using LiftLog.Data;
using Microsoft.AspNetCore.Components;

namespace LiftLog.Pages;

public partial class ProgramsPage : ComponentBase
{
    private List<WorkoutProgram>? programs;

    private bool _showEdit = false;

    protected override async Task OnInitializedAsync()
    {
        programs = new List<WorkoutProgram>()
        {
            new WorkoutProgram
            {
                Id = 1,
                Name = "Arms",
            },
            new WorkoutProgram
            {
                Id = 2,
                Name = "Legs",
            },
            new WorkoutProgram
            {
                Id = 3,
                Name = "Chest",
            },
            new WorkoutProgram
            {
                Id = 4,
                Name = "Back",
            },

        };
    }
    private void LoadData()
    {
        _showEdit = !_showEdit;
        StateHasChanged();
    }
}
