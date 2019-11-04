using System.Threading;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;

namespace CQRS.Execution.Tests
{
    public class SampleQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        public SampleQueryHandlerDecorator(IQueryHandler<TQuery, TResult> queryHandler)
        {
        }

        public Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(default(TResult));
        }
    }
}