namespace CQRS.Execution
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS.Command.Abstractions;
    using CQRS.Query.Abstractions;

    /// <summary>
    /// Extends the <see cref="ICommandExecutor"/> interface
    /// with the ability to execute a command in its own scope.
    /// </summary>
    public static class ScopedCommandExecutorExtensions
    {
        /// <summary>
        /// Executes the specified command in its own scope.
        /// </summary>
        /// <typeparam name="TCommand">The type of command to execute.</typeparam>
        /// <param name="commandExecutor">The target <see cref="ICommandExecutor"/>.</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> that can be used by other objects or threads to receive
        /// notice of cancellation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ExecuteScopedAsync<TCommand>(this ICommandExecutor commandExecutor, TCommand command, CancellationToken cancellationToken = default)
            => await commandExecutor.ExecuteAsync(new ScopedCommand<TCommand>(command), cancellationToken);

        /// <summary>
        /// Executes the specified query in its own scope.
        /// </summary>
        /// <typeparam name="TResult">The type of result returned by the query.</typeparam>
        /// <param name="queryExecutor">The target <see cref="IQueryExecutor"/>.</param>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken"> A <see cref="CancellationToken"/> that can be used by other objects or threads to receive
        /// notice of cancellation.</param>
        /// <returns>A <see cref="Task{T}"/> representing the asynchronous operation and the result.</returns>
        public static async Task<TResult> ExecuteScopedAsync<TResult>(this IQueryExecutor queryExecutor, IQuery<TResult> query, CancellationToken cancellationToken = default)
             => await queryExecutor.ExecuteAsync(new ScopedQuery<TResult>(query), cancellationToken);
    }
}