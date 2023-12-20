namespace CQRS.Execution.Tests
{
    public class QueryHandlerScopeFactory : IQueryHandlerScopeFactory
    {
        public IQueryHandlerScope CreateScope()
        {
            return new QueryHandlerScope();
        }
    }
}