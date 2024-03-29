namespace CQRS.Execution
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS.Query.Abstractions;

    /// <summary>
    /// Executes query handlers.
    /// </summary>
    public class QueryExecutor : IQueryExecutor
    {
        private static readonly MethodInfo GetQueryHandlerMethod;
        private readonly IQueryHandlerFactory queryHandlerFactory;

        static QueryExecutor() => GetQueryHandlerMethod = typeof(IQueryHandlerFactory).GetMethod(nameof(IQueryHandlerFactory.GetQueryHandler));

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryExecutor"/> class.
        /// </summary>
        /// <param name="queryHandlerFactory">The <see cref="IQueryHandlerFactory"/>
        /// that is responsible for creating query handlers.</param>
        public QueryExecutor(IQueryHandlerFactory queryHandlerFactory)
        {
            this.queryHandlerFactory = queryHandlerFactory;
        }

        /// <inheritdoc/>
        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            var queryDelegate = Cache<TResult>.GetOrAdd(query.GetType(), CreateDelegate<TResult>);
            return await queryDelegate(queryHandlerFactory, query, cancellationToken).ConfigureAwait(false);
        }

        private static Func<IQueryHandlerFactory, IQuery<TResult>, CancellationToken, Task<TResult>> CreateDelegate<TResult>(Type queryType)
        {
            // Create the closed generic query handler type.
            Type queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));

            // Get the MethodInfo that represents the HandleAsync method.
            MethodInfo handleAsyncMethod = queryHandlerType.GetMethod("HandleAsync");

            var queryHandlerFactoryParameter = Expression.Parameter(typeof(IQueryHandlerFactory));

            var queryParameter = Expression.Parameter(typeof(IQuery<TResult>));

            var cancellationTokenParameterExpression = Expression.Parameter(typeof(CancellationToken));

            var queryHandlerTypeConstant = Expression.Constant(queryHandlerType);

            var getQueryHandlerMethodCallExpression = Expression.Call(queryHandlerFactoryParameter, GetQueryHandlerMethod, queryHandlerTypeConstant);

            var handleAsyncMethodCallExpression = Expression.Call(
                    Expression.Convert(getQueryHandlerMethodCallExpression, queryHandlerType),
                    handleAsyncMethod,
                    Expression.Convert(queryParameter, queryType),
                    cancellationTokenParameterExpression);

            var lambdaExpression = Expression.Lambda<Func<IQueryHandlerFactory, IQuery<TResult>, CancellationToken, Task<TResult>>>(
                    handleAsyncMethodCallExpression,
                    true,
                    queryHandlerFactoryParameter,
                    queryParameter,
                    cancellationTokenParameterExpression);

            return lambdaExpression.Compile();
        }

        private static class Cache<TResult>
        {
            private static ConcurrentDictionary<Type, Func<IQueryHandlerFactory, IQuery<TResult>, CancellationToken, Task<TResult>>> cache = new ConcurrentDictionary<Type, Func<IQueryHandlerFactory, IQuery<TResult>, CancellationToken, Task<TResult>>>();

            public static Func<IQueryHandlerFactory, IQuery<TResult>, CancellationToken, Task<TResult>> GetOrAdd(Type queryType, Func<Type, Func<IQueryHandlerFactory, IQuery<TResult>, CancellationToken, Task<TResult>>> delegateFactory)
            {
                return cache.GetOrAdd(queryType, t => delegateFactory(t));
            }
        }
    }
}