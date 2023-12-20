namespace CQRS.Execution
{
    /// <summary>
    /// Represents a factory for creating an <see cref="ICommandHandlerScope"/>.
    /// </summary>
    public interface IQueryHandlerScopeFactory
    {
        /// <summary>
        /// Creates a new <see cref="ICommandHandlerScope"/>.
        /// </summary>
        /// <returns><see cref="ICommandHandlerScope"/> instance.</returns>
        IQueryHandlerScope CreateScope();
    }
}