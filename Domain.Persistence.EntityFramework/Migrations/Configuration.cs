using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Entities.Implementation.City;

namespace Domain.Persistence.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Persistence.EntityFramework.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EntityFrameworkContext context)
        {
            var codeBase = System.Reflection.Assembly.GetExecutingAssembly()
                                 .GetName()
                                 .CodeBase;

            if (Regex.IsMatch(codeBase, @"^file:[/]{2,3}"))
            {
                codeBase = Regex.Replace(codeBase, @"^file:[/]{2,3}", "")
                                   .Replace("/", @"\");
            }

            if (!Regex.IsMatch(codeBase, @"^[a-zA-Z]:/"))            {                codeBase = "//" + codeBase;            }

            string binDirectory = null;

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
            }

            base.Seed(context);
        }

        private string ReadFile(string filename)
        {
            using (var fstream = File.Open(filename, FileMode.Open))
            {
                var bytes = new byte[fstream.Length];
                fstream.Read(bytes, 0, bytes.Length);

                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}
