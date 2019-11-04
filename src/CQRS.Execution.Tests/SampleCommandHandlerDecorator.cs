using System.Threading;
using System.Threading.Tasks;
using CQRS.Command.Abstractions;

namespace CQRS.Execution.Tests
{
    public class SampleCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        public SampleCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler)
        {
        }

        public Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}