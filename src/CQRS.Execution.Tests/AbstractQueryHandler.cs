using System.Threading;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;

namespace CQRS.Execution.Tests
{
    public abstract class AbstractQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult[]> where TQuery : IQuery<TResult[]>
    {
        public AbstractQueryHandler()
        {
        }

        public virtual Task<TResult[]> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(default(TResult[]));
        }
    }
}