using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.Persistence.EntityFramework.Conventions
{
    /// <summary>
    /// Устанавливает для всех свойств типа DateTime тип данных datetime2 в БД
    /// </summary>
    class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            this.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}