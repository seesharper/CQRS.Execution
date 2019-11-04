namespace CQRS.Execution.Tests
{
    using CQRS.Command.Abstractions;
    using CQRS.Execution;
    using CQRS.Query.Abstractions;
    using FluentAssertions;
    using Xunit;

    public class AssemblyExtensionsTests
    {
        [Fact]
        public void ShouldFindCommandHandlers()
        {
            var commandHandlers = typeof(AssemblyExtensionsTests).Assembly.GetCommandHandlerDescriptors();

            commandHandlers.Length.Should().Be(1);
            commandHandlers[0].HandlerType.Should().Be(typeof(ICommandHandler<SampleCommand>));
            commandHandlers[0].ImplementingType.Should().Be(typeof(SampleCommandHandler));
        }

        [Fact]
        public void ShouldFindQueryHandlers()
        {
            var queryHandlers = typeof(AssemblyExtensionsTests).Assembly.GetQueryHandlerHandlerDescriptors();

            queryHandlers.Length.Should().Be(1);
            queryHandlers[0].HandlerType.Should().Be(typeof(IQueryHandler<SampleQuery, SampleQueryResult>));
            queryHandlers[0].ImplementingType.Should().Be(typeof(SampleQueryHandler));
        }
    }
}