using CQRS.Command.Abstractions;
namespace CQRS.Execution.Tests
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<TCommand> CreateCommandHandler<TCommand>()
        {
            return new SampleCommandHandler() as ICommandHandler<TCommand>;
        }
    }
}