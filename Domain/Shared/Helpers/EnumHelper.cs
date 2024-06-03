using System.ComponentModel;

namespace Domain.Shared.Helpers;

public static class EnumHelper
{
    public static string? GetDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);

        if (name != null)
        {
            var field = type.GetField(name);

            if (field != null)
            {
                var attr = Attribute.GetCustomAttribute(field,typeof(DescriptionAttribute)) 
                                    as DescriptionAttribute;

                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }

        return null;
    }

}