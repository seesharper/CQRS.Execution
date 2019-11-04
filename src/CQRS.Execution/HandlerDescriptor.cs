namespace CQRS.Execution
{
    using System;

    /// <summary>
    /// Represents a description of a command/query handler.
    /// </summary>
    public class HandlerDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HandlerDescriptor"/> class.
        /// </summary>
        /// <param name="handlerType">The handler interface type.</param>
        /// <param name="implementingType">The implementing type of the handler.</param>
        public HandlerDescriptor(Type handlerType, Type implementingType)
        {
            HandlerType = handlerType;
            ImplementingType = implementingType;
        }

        /// <summary>
        /// Gets the handler interface type.
        /// </summary>
        public Type HandlerType { get; }

        /// <summary>
        /// Gets the implementing type of the handler.
        /// </summary>
        public Type ImplementingType { get; }
    }
}