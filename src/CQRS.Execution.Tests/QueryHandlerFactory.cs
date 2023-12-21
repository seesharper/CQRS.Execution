using System;
using CQRS.Execution;
using CQRS.Query.Abstractions;

namespace CQRS.Execution.Tests
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        public object GetQueryHandler(Type queryHandlerType)
        {
            if (queryHandlerType == typeof(IQueryHandler<SampleQuery, SampleQueryResult>))
                return new SampleQueryHandler();


            var scopedQueryHandlerType = typeof(ScopedQueryHandler<,>).MakeGenericType(typeof(ScopedQuery<SampleQueryResult>), typeof(SampleQueryResult));
            var instance = System.Activator.CreateInstance(scopedQueryHandlerType, new QueryHandlerScopeFactory());
            return instance;
        }
    }
}