using System;
using System.Threading.Tasks;
using Autofac;
using Sirius.Abstraction.CQRS;

namespace Siruis.Application.Buses
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = ResolveHandler(command);
            
            await commandHandler.Execute(command);
        }

        private ICommandHandler<TCommand> ResolveHandler<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _lifetimeScope.ResolveOptional<ICommandHandler<TCommand>>();
            if (commandHandler == null)
            {
                throw new InvalidOperationException("Command handler not found");
            }
            return commandHandler;
        }
    }
}