namespace CQRS.Execution
{
    using System;
    using CQRS.Command.Abstractions;
    using CQRS.Query.Abstractions;

    /// <summary>
    /// Represents a scope for a handler.
    /// </summary>
    public interface IQueryHandlerScope : IDisposable
    {
        /// <summary>
        /// Creates a command executor.
        /// </summary>
        /// <returns>The <see cref="ICommandExecutor"/> used to execute the command.</returns>
        IQueryExecutor CreateQueryExecutor();
    }
}