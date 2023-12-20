using CQRS.Query.Abstractions;

namespace CQRS.Execution.Tests
{
    public class QueryHandlerScope : IQueryHandlerScope
    {
        public IQueryExecutor CreateQueryExecutor()
        {
            return new QueryExecutor(new QueryHandlerFactory());
        }

        public void Dispose()
        {
        }
    }
}