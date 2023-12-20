using CQRS.Command.Abstractions;

namespace CQRS.Execution.Tests
{
    public class CommandHandlerScope : ICommandHandlerScope
    {
        public ICommandExecutor CreateCommandExecutor()
        {
            return new CommandExecutor(new CommandHandlerFactory());
        }

        public void Dispose()
        {
        }
    }
}