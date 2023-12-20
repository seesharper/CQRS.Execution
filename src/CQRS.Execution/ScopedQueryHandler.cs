using System.Threading;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;

namespace CQRS.Execution
{
    public class ScopedQueryHandler<TQuery, TResult> : IQueryHandler<ScopedQuery<TResult>, TResult>
    {
        private readonly IQueryHandlerScopeFactory handlerScopeFactory;

        public ScopedQueryHandler(IQueryHandlerScopeFactory handlerScopeFactory)
            => this.handlerScopeFactory = handlerScopeFactory;


        public Task<TResult> HandleAsync(ScopedQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            using (var scope = handlerScopeFactory.CreateScope())
            {
                var queryExecutor = scope.CreateQueryExecutor();
                return queryExecutor.ExecuteAsync(query.Query, cancellationToken);
            }
        }
    }

}