using System.Threading.Tasks;

namespace CQRS.Execution.Tests;

public class QueryHandlerScopeFactory : IQueryHandlerScopeFactory
{
    public ValueTask<IQueryHandlerScope> CreateScopeAsync()
    {
        return ValueTask.FromResult<IQueryHandlerScope>(new QueryHandlerScope());
    }
}
