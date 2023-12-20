using CQRS.Command.Abstractions;
namespace CQRS.Execution.Tests
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<TCommand> CreateCommandHandler<TCommand>()
        {
            if (typeof(TCommand) == typeof(SampleCommand))
                return new SampleCommandHandler() as ICommandHandler<TCommand>;
            else
            {
                var commandType = typeof(TCommand).GenericTypeArguments[0];
                var scopedCommandHandlerType = typeof(ScopedCommandHandler<>).MakeGenericType(commandType);
                var instance = System.Activator.CreateInstance(scopedCommandHandlerType, new CommandHandlerScopeFactory());
                return instance as ICommandHandler<TCommand>;
            }

        }
    }
}