using FluentValidation;
using SimpleInjector;

namespace Client.Api.v1.Models.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterClientApiV1ModelsDependencies(this Container container)
        {
            container.Register(typeof (IValidator<>), new[] { typeof (ContainerExtensions).Assembly }, Lifestyle.Transient);
        }
    }
}