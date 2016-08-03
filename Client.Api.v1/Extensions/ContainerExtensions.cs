using Client.Api.v1.Models.Extensions;
using FluentMailer.Factory;
using FluentMailer.Interfaces;
using SimpleInjector;

namespace Client.Api.v1.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterClientApiV1Dependencies(this Container container)
        {
            container.Register(typeof (IFluentMailer), FluentMailerFactory.Create);
            container.RegisterClientApiV1ModelsDependencies();
        }
    }
}