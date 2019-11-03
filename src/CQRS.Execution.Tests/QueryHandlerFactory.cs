using System;
using CQRS.Execution.Abstractions;

namespace CQRS.Execution.Tests
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        public object GetQueryHandler(Type queryHandlerType)
        {
            return new SampleQueryHandler();
        }
    }
}