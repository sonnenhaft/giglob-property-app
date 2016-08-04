using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Persistence.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EntityFrameworkContext context)
        {
            var codeBase = Assembly.GetExecutingAssembly()
                                   .GetName()
                                   .CodeBase;

            if (Regex.IsMatch(codeBase, @"^file:[/]{2,3}"))
            {
                codeBase = Regex.Replace(codeBase, @"^file:[/]{2,3}", "")
                                .Replace("/", @"\");
            }
            if (!Regex.IsMatch(codeBase, @"^[a-zA-Z]:\\"))
            {
                codeBase = "//" + codeBase;
            }

            string binDirectory;

            try
            {
                binDirectory = Path.GetDirectoryName(codeBase);
            }
            catch (Exception)
            {
                binDirectory = codeBase.Substring(0, codeBase.LastIndexOf(@"\"));
            }

            if (binDirectory != null)
            {
                context.Database.ExecuteSqlCommand(ReadFile(binDirectory + @"\SQL\cities.sql"));
                context.Database.ExecuteSqlCommand(ReadFile(binDirectory + @"\SQL\districts.sql"));
                context.Database.ExecuteSqlCommand(ReadFile(binDirectory + @"\SQL\metrobranches.sql"));
            }

            base.Seed(context);
        }

        private string ReadFile(string filename)
        {
            using (var fstream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var bytes = new byte[fstream.Length];
                fstream.Read(bytes, 0, bytes.Length);

                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}