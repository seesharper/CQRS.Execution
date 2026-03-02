using System.Threading.Tasks;

namespace CQRS.Execution.Tests;

public class CommandHandlerScopeFactory : ICommandHandlerScopeFactory
{
    public ValueTask<ICommandHandlerScope> CreateScopeAsync()
    {
        return ValueTask.FromResult<ICommandHandlerScope>(new CommandHandlerScope());
    }
}
