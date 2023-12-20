namespace CQRS.Execution
{
    /// <summary>
    /// Represents a command that requires its own scope.
    /// </summary>
    /// <typeparam name="TCommand">The type of command to be handled.</typeparam>
    public class ScopedCommand<TCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedCommand{TCommand}"/> class.
        /// </summary>
        /// <param name="command">The type of command to be handled.</param>
        public ScopedCommand(TCommand command) => Command = command;

        /// <summary>
        /// Gets the command to be executed in its own scope.
        /// </summary>
        public TCommand Command { get; }
    }
}