using System.Threading;
using System.Threading.Tasks;
using CQRS.Command.Abstractions;
using CQRS.Query.Abstractions;

namespace CQRS.Execution.Tests
{
    public abstract class AbstractCommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        public AbstractCommandHandler()
        {
        }

        public Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}