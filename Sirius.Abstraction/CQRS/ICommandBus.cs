using System.Threading.Tasks;

namespace Sirius.Abstraction.CQRS
{
    public interface ICommandBus
    {
        Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}