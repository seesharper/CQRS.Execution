namespace CQRS.Execution
{
    using System;
    using CQRS.Query.Abstractions;

    /// <summary>
    /// Represents a class that is capable of
    /// providing an <see cref="IQueryHandler{TQuery, TResult}"/> instance.
    /// </summary>
    public interface IQueryHandlerFactory
    {
        /// <summary>
        /// Create a class that implements <see cref="IQueryHandler{TQuery,TResult}"/>.
        /// </summary>
        /// <param name="queryHandlerType">The type of query handler to create.</param>
        /// <returns>A class that implements <see cref="IQueryHandler{TQuery,TResult}"/>.</returns>
        object GetQueryHandler(Type queryHandlerType);
    }
}