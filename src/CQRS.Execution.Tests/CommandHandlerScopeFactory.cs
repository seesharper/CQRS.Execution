namespace CQRS.Execution.Tests
{
    public class CommandHandlerScopeFactory : ICommandHandlerScopeFactory
    {
        public ICommandHandlerScope CreateScope()
        {
            return new CommandHandlerScope();
        }
    }
}