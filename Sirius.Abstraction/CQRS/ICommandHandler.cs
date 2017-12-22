using System.Threading.Tasks;

namespace Sirius.Abstraction.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}