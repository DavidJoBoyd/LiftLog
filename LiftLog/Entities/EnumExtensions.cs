using System.ComponentModel;
using System.Reflection;
namespace LiftLog.Entities;

public static class EnumExtensions
{
    public static string? GetDescription<TEnum>(this TEnum item) where TEnum : struct, IConvertible
    {
        if (!typeof(TEnum).IsEnum)
        {
            throw new ArgumentException("TEnum must be an enumerated type");
        }

        var descriptionAttribute = item.GetType()
            .GetMember(item.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute?.Description ?? item.ToString();
    }
}