namespace CQRS.Execution
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS.Query.Abstractions;

    /// <summary>
    /// An IQueryHandler{TQuery,TResult} implementation that creates a new scope and executes the query in that scope.
    /// </summary>
    /// <typeparam name="TQuery">The type of query to be executed.</typeparam>
    /// <typeparam name="TResult">The type of result from the query.</typeparam>
    public class ScopedQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : ScopedQuery<TResult>, IQuery<TResult>
    {
        private readonly IQueryHandlerScopeFactory handlerScopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedQueryHandler{TQuery, TResult}"/> class.
        /// </summary>
        /// <param name="handlerScopeFactory">The <see cref="IQueryHandlerScopeFactory"/> that is responsible for creating the query handler scope.</param>
        public ScopedQueryHandler(IQueryHandlerScopeFactory handlerScopeFactory)
            => this.handlerScopeFactory = handlerScopeFactory;

        /// <summary>
        /// Executes the given query in a new scope.
        /// </summary>
        /// <param name="query">The query to be executed.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>THe result from the query.</returns>
        public Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
        {
            using (var scope = handlerScopeFactory.CreateScope())
            {
                var queryExecutor = scope.CreateQueryExecutor();
                return queryExecutor.ExecuteAsync(query.Query, cancellationToken);
            }
        }
    }
}