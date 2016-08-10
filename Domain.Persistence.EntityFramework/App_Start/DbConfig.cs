using SqlServerTypes;

namespace Domain.Persistence.EntityFramework
{
    public class DbConfig
    {
        public static void Configure(string binariesPath)
        {
            Utilities.LoadNativeAssemblies(binariesPath);
        }
    }
}