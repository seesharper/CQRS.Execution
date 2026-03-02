using System.Threading.Tasks;
using CQRS.Command.Abstractions;

namespace CQRS.Execution.Tests;

public class CommandHandlerScope : ICommandHandlerScope
{
    public ICommandExecutor CreateCommandExecutor()
    {
        return new CommandExecutor(new CommandHandlerFactory());
    }

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
