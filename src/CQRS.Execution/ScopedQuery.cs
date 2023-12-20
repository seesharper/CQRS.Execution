namespace CQRS.Execution
{
    using CQRS.Query.Abstractions;

    /// <summary>
    /// Represents a query that requires its own scope.
    /// </summary>
    /// <typeparam name="TResult">The type of result return by the query.</typeparam>
    public class ScopedQuery<TResult> : IQuery<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedQuery{TResult}"/> class.
        /// </summary>
        /// <param name="query">The type of query to be handled.</param>
        public ScopedQuery(IQuery<TResult> query) => Query = query;

        /// <summary>
        /// Gets the query to be executed in its own scope.
        /// </summary>
        public IQuery<TResult> Query { get; }
    }
}
