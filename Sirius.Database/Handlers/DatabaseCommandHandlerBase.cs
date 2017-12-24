﻿using System.Threading.Tasks;
using Sirius.Abstraction.CQRS;
using Sirius.Database.Context;

namespace Sirius.Database.Handlers
{
    public abstract class DatabaseCommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand: ICommand
    {
        protected readonly ISiriusDbContext DbContext;

        protected DatabaseCommandHandlerBase(ISiriusDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task Execute(TCommand context);
    }
}