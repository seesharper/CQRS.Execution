using System;
using CQRS.Execution;

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