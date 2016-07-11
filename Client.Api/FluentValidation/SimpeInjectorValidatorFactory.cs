using System;
using FluentValidation;
using SimpleInjector;

namespace Client.Api.FluentValidation
{
    public class SimpeInjectorValidatorFactory: ValidatorFactoryBase
    {
        private readonly Container _container;

        public SimpeInjectorValidatorFactory(Container container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = null;

            try
            {
                validator = _container.GetInstance(validatorType) as IValidator;
            }
            catch (ActivationException) { }

            return validator;
        }
    }
}