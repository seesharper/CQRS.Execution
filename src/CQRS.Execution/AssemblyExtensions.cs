namespace CQRS.Execution
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CQRS.Command.Abstractions;
    using CQRS.Query.Abstractions;

    /// <summary>
    /// Extends the <see cref="Assembly"/> class with extension methods
    /// for searching for command and query handler implementations.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets a list of handler descriptors that represents implementation of the <see cref="ICommandHandler{TCommand}"/> interface.
        /// </summary>
        /// <param name="assembly">The target <see cref="Assembly"/> for which to get handler descriptors.</param>
        /// <returns>A list of handler descriptors.</returns>
        public static HandlerDescriptor[] GetCommandHandlerDescriptors(this Assembly assembly)
        {
            var commandTypes =
               assembly
                    .GetTypes()
                    .Select(t => GetHandlerDescriptor(t, typeof(ICommandHandler<>)))
                    .Where(m => m != null);
            return commandTypes.ToArray();
        }

        /// <summary>
        /// Searches the given <paramref name="assembly"/> for <see cref="IQueryHandler{TQuery,TResult}"/> implementations.
        /// </summary>
        /// <param name="assembly">The target <see cref="Assembly"/> for which to get handler descriptors.</param>
        /// <returns>A list of handler descriptors that represents implementation of the <see cref="IQueryHandler{TQuery,TResult}"/> interface.</returns>
        public static HandlerDescriptor[] GetQueryHandlerHandlerDescriptors(this Assembly assembly)
        {
            var commandTypes =
               assembly
                    .GetTypes()
                    .Select(t => GetHandlerDescriptor(t, typeof(IQueryHandler<,>)))
                    .Where(m => m != null);
            return commandTypes.ToArray();
        }

        private static HandlerDescriptor GetHandlerDescriptor(Type type, Type openGenericHandlerType)
        {
            var closedGenericInterface = type.GetInterfaces().SingleOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == openGenericHandlerType);

            if (closedGenericInterface != null)
            {
                var constructor = type.GetConstructors().FirstOrDefault();
                if (constructor != null)
                {
                    var isDecorator = constructor.GetParameters().Select(p => p.ParameterType).Contains(closedGenericInterface);
                    if (!isDecorator)
                    {
                        return new HandlerDescriptor(closedGenericInterface, type);
                    }
                }
            }

            return null;
        }
    }
}