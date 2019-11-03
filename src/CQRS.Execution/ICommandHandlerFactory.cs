namespace CQRS.Execution.Abstractions
{
    using CQRS.Command.Abstractions;

    /// <summary>
    /// Represents a class that is capable of
    /// providing an <see cref="ICommandHandler{TCommand}"/> instance.
    /// </summary>
    public interface ICommandHandlerFactory
    {
        /// <summary>
        /// Create a class that implements <see cref="ICommandHandler{TCommand}"/>.
        /// </summary>
        /// <typeparam name="TCommand">The type of command for which to create a command handler.</typeparam>
        /// <returns>A class that implements <see cref="ICommandHandler{TCommand}"/>.</returns>
        ICommandHandler<TCommand> CreateCommandHandler<TCommand>();
    }
}
