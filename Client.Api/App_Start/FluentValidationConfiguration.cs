using System.Web.Http;
using System.Web.Http.Validation;
using Client.Api.ActionFilters;
using FluentValidation;
using FluentValidation.WebApi;

namespace Client.Api
{
    public class FluentValidationConfiguration
    {
        public static void Configure(HttpConfiguration configuration, ModelStateValidatorActionFilter modelStateValidatorActionFilter, IValidatorFactory validatorFactory)
        {
            configuration.Filters.Add(modelStateValidatorActionFilter);
            configuration.Services.Clear(typeof (ModelValidatorProvider));
            FluentValidationModelValidatorProvider.Configure(configuration, provider => provider.ValidatorFactory = validatorFactory);
        }
    }
}