using System.ComponentModel;

namespace Domain.Enums
{
    public enum Exercise
    {
        [Description("Squat")]
        Squat = 0,

        [Description("Bench Press")]
        BenchPress = 1,

        [Description("Deadlift")]
        Deadlift = 2,

        [Description("Overhead Press")]
        OverheadPress = 3,

        [Description("Barbell Row")]
        BarbellRow = 4
    }
}
