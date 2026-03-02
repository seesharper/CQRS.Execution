namespace CQRS.Execution;

using System;
using CQRS.Query.Abstractions;

/// <summary>
/// Represents a scope for a handler.
/// </summary>
public interface IQueryHandlerScope : IAsyncDisposable
{
    /// <summary>
    /// Creates a query executor.
    /// </summary>
    /// <returns>The <see cref="IQueryExecutor"/> used to execute the query.</returns>
    IQueryExecutor CreateQueryExecutor();
}
