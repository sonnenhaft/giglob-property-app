using System;
using System.Linq;

namespace Domain.Extensions
{
    public static class EnumExtensions
    {
        public static bool IsEnumSingleValue(this Enum value)
        {
            var type = value.GetType();
            var values = Enum.GetValues(type)
                             .Cast<Enum>()
                             .Select(Convert.ToInt64);
            var valueLong = Convert.ToInt64(value);

            return values.Any(x => x == valueLong);
        }
    }
}