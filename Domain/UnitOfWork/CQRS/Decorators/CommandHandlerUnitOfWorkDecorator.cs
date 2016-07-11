using System;
using ConquerorsFramework;

namespace Domain.UnitOfWork.CQRS.Decorators
{
    public class CommandHandlerUnitOfWorkDecorator<TCommand>: ICommandHandler<TCommand>
        where TCommand: ICommand
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICommandHandler<TCommand> _decoratee;

        public CommandHandlerUnitOfWorkDecorator(IUnitOfWorkFactory unitOfWorkFactory, ICommandHandler<TCommand> decoratee)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _decoratee = decoratee;
        }

        public void Handle(TCommand message)
        {
            using(var uow = _unitOfWorkFactory.Create())
            {
                try
                {
                    _decoratee.Handle(message);
                }
                catch(Exception)
                {
                    uow.Rollback();
                    throw;
                }

                uow.Commit();
            }
        }
    }
}