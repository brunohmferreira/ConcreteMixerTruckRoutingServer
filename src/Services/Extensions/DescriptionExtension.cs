using System.ComponentModel;
using System.Reflection;

namespace ConcreteMixerTruckRoutingServer.Services.Extensions
{
    public static class DescriptionExtension
    {
        public static string Description<TObject>(this TObject value)
        {
            var field = value?.GetType().GetField(value?.ToString() ?? string.Empty);
            if (field == null) return null;
            var attribute = (DescriptionAttribute?)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute?.Description ?? string.Empty;
        }

        public static string GetCustomDescription(object objEnum)
        {
            var field = objEnum.GetType().GetField(objEnum?.ToString() ?? string.Empty);
            var attributes = (DescriptionAttribute[]?)field?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes?.Length > 0) ? attributes[0]?.Description ?? string.Empty : objEnum?.ToString() ?? string.Empty;
        }

        public static string DescriptionEnum(this Enum value)
        {
            return GetCustomDescription(value);
        }
    }
}
