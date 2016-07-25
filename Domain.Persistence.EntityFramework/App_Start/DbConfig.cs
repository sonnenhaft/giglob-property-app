namespace Domain.Persistence.EntityFramework
{
    public class DbConfig
    {
        public static void Configure(string binariesPath)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(binariesPath);
        }
    }
}