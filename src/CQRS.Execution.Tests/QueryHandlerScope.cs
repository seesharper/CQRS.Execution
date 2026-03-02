using System.Threading.Tasks;
using CQRS.Query.Abstractions;

namespace CQRS.Execution.Tests;

public class QueryHandlerScope : IQueryHandlerScope
{
    public IQueryExecutor CreateQueryExecutor()
    {
        return new QueryExecutor(new QueryHandlerFactory());
    }

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
